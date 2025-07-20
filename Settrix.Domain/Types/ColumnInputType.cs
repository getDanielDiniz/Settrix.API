namespace Settrix.Domain.Types;
public enum ColumnInputType
{
    //Upper case because is reserved words!
    STRING = 0,
    DECIMAL = 1,
    BOOLEAN = 2,
    DATETIME = 3,
    DATEONLY = 4,
    VALUE_LIST = 5,
    EMAIL = 6,
    CELLPHONE = 7,
    CNPJ = 8,
    URL = 9,
    CASH = 10,
}
