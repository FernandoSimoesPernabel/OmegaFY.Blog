using System;

namespace OmegaFY.Blog.Common.Helpers
{

    public static class GarbageColletorHelper
    {

        public static int ObterQuantidadeColecoesGenX(int geracaoGC) => GC.CollectionCount(geracaoGC);

    }

}
