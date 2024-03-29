﻿using System;
using System.Threading.Tasks;
using Xunit;
using Shared.ExceptionHandling;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace UnitTests.Middleware
{
    public class ExceptionMiddlewareTests
    {
        private readonly ILoggerFactory loggerFactory;

        public ExceptionMiddlewareTests()
        {
            loggerFactory = new LoggerFactory();
        }

        [Fact]
        public async Task InvokeAsync_NoExceptionThrownInsideMiddleware_ContextResponseNotModifiedAsync()
        {
            //arrange
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
                {
                    await Task.Run(() =>
                    {
                        return HttpStatusCode.OK;
                    });
                },  loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal("", body);
        }

        [Fact]
        public async Task InvokeAsync_InternalServerErrorThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Internal server error\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
                {
                    await Task.Run(() =>
                    {
                        throw new Exception();
                    });
                }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

        [Fact]
        public async Task InvokeAsync_ValidationExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"Bad Request\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new ValidationException("Bad Request");
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

        [Fact]
        public async Task InvokeAsync_UnauthorizedAccessExceptionThrownInsideMiddleware_ContextResponseModifiedAsync()
        {
            //arrange
            string expectedOutput = "{\"Message\":\"You have no access\"}";
            var middleWare = new ExceptionMiddleware(next: async (innerHttpContext) =>
            {
                await Task.Run(() =>
                {
                    throw new UnauthorizedAccessException();
                });
            }, loggerFactory);
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //act
            await middleWare.InvokeAsync(context);

            //assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var body = reader.ReadToEnd();
            Assert.Equal(expectedOutput, body);
        }

    }
}
