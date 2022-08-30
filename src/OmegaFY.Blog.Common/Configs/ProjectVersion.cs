using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmegaFY.Blog.Common.Abstract;

namespace OmegaFY.Blog.Common.Configs;

public sealed class ProjectVersion : AbstractLazySingleton<ProjectVersion>
{
    public Version Version { get; }

    public ProjectVersion() => Version = System.Reflection.Assembly.GetAssembly(typeof(ProjectVersion)).GetName().Version;

    public override string ToString() => Version.ToString();
}