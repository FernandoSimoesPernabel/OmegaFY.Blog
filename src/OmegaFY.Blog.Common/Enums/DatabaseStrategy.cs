namespace OmegaFY.Blog.Common.Enums
{

    /// <summary>
    /// Estrategia para definir onde sera persistido os dados pelos repositorios.
    /// </summary>
    public enum DatabaseStrategy
    {

        /// <summary>
        /// Persistência em memoria, não grava em disco os dados e os mesmos são perdidos ao finalizar a aplicação.
        /// </summary>
        InMemoryDB = 0,

        /// <summary>
        /// Persistência utilizando uma base de dados SQL Server.
        /// </summary>
        SqlServer = 1,

        /// <summary>
        /// Persistência utlizando uma base de dados MongoDB.
        /// </summary>
        MongoDB = 2,

        /// <summary>
        /// Persistência utilizando um banco de dados local SQLite embarcado com a aplicação.
        /// </summary>
        SQLite = 3

    }

}
