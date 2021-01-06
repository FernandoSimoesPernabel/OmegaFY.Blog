using System.Diagnostics;

namespace OmegaFY.Blog.Common.Helpers
{
    public static class SystemMemoryHelper
    {

        public static long ObterMemoriaEmUsoProcessoAtualEmMB()
        {
            short divisaoMegaByte = 1024;
            return Process.GetCurrentProcess().WorkingSet64 / divisaoMegaByte / divisaoMegaByte;
        }

    }

}
