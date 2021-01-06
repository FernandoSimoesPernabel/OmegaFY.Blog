using Microsoft.AspNetCore.Http;
using OmegaFY.Blog.Common.Helpers;
using OmegaFY.Blog.WebAPI.Middlewares.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OmegaFY.Blog.WebAPI.Middlewares
{

    public class GarbageColletorMiddleware : MiddlewareBase
    {

        public GarbageColletorMiddleware(RequestDelegate next) : base(next) { }

        public async override Task InvokeAsync(HttpContext httpContext)
        {
            Stopwatch stopwatch = new Stopwatch();

            int inicialGen0 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(0);
            int inicialGen1 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(1);
            int inicialGen2 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(2);

            stopwatch.Start();

            await _next(httpContext);

            stopwatch.Stop();

            int finalGen0 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(0);
            int finalGen1 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(1);
            int finalGen2 = GarbageColletorHelper.ObterQuantidadeColecoesGenX(2);

            Console.WriteLine($"Tempo -> {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine($"Gen0 -> { finalGen0 - inicialGen0}");
            Console.WriteLine($"Gen1 -> { finalGen1 - inicialGen1}");
            Console.WriteLine($"Gen2 -> { finalGen2 - inicialGen2}");
            Console.WriteLine($"Memoria -> {SystemMemoryHelper.ObterMemoriaEmUsoProcessoAtualEmMB()}");
        }

    }

}
