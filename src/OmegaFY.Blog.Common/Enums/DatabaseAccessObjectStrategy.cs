namespace OmegaFY.Blog.Common.Enums
{

    /// <summary>
    /// Estrategia para definir a ferramenta para escrita e leitura dos dados gerados pela aplicação.
    /// </summary>
    public enum DatabaseAccessObjectStrategy
    {

        /// <summary>
        /// Acesso aos dados utilizando o Entity Framework Core (SQL Server, SQLite e InMemory).
        /// </summary>
        EntityFramework = 0,

        /// <summary>
        /// Acesso aos dados utilizando o Dapper (SQL Server e SQLite).
        /// </summary>
        Dapper = 1,

        /// <summary>
        /// Acesso aos dados utilizando o MongoDriver (MongoDB).
        /// </summary>
        MongoDriver = 2

    }

}
