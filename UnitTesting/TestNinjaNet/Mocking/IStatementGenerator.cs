namespace TestNinjaNet.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }
}