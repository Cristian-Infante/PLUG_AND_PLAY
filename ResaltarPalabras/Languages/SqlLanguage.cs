using ResaltarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Languages;

public class SqlLanguage : ILanguage
{
    public string Name => "SQL";

    public HashSet<string> ReservedWords =>
    [
        "ADD", "ALL", "ALTER", "AND", "ANY", "AS", "ASC", "AUTO_INCREMENT", "BACKUP", "BETWEEN", "BY", "CASE", "CHAR", "CHECK", "COLUMN", "CONSTRAINT", "CREATE", "CROSS", "CURDATE", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_USER", "CURTIME", "DATABASE", "DATE", "DATETIME", "DAY", "DECIMAL", "DEFAULT", "DELETE", "DESC", "DISTINCT", "DROP", "ELSE", "END", "EXEC", "EXISTS", "FILE", "FLOAT", "FOREIGN", "FROM", "FULL", "FUNCTION", "GETDATE", "GRANT", "GROUP", "HAVING", "HOUR", "IN", "INDEX", "INNER", "INSERT", "INT", "INTO", "IS", "JOIN", "KEY", "LEFT", "LIKE", "LIMIT", "MAX", "MIN", "MINUTE", "MODIFY", "MONTH", "NATURAL", "NOT", "NOW", "NULL", "NUMERIC", "ON", "OR", "ORDER", "OUTER", "PASSWORD", "PRIMARY", "PRIVILEGES", "PROCEDURE", "REAL", "REFERENCES", "RELOAD", "RENAME", "REVOKE", "RIGHT", "ROWNUM", "SECOND", "SELECT", "SESSION_USER", "SET", "SHOW", "SHUTDOWN", "SUM", "SUPER", "SYSTEM_USER", "TABLE", "TEXT", "THEN", "TIME", "TIMESTAMP", "TO", "TOP", "TRIGGER", "TRUNCATE", "UNION", "UNIQUE", "UPDATE", "USER", "USING", "VALUES", "VARCHAR", "VIEW", "WHEN", "WHERE", "YEAR"
    ];

    public bool IsMatch(string content)
    {
        var patterns = new List<string>
        {
            @"SELECT\s+", @"INSERT\s+INTO", @"UPDATE\s+\w+", @"DELETE\s+FROM", @"CREATE\s+TABLE", @"ALTER\s+TABLE", @"DROP\s+TABLE"
        };

        return patterns.Any(pattern => Regex.IsMatch(content, pattern, RegexOptions.IgnoreCase));
    }
}