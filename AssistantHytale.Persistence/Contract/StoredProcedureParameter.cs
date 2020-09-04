using System;
using System.Data;

namespace AssistantHytale.Persistence.Contract
{
    public class StoredProcedureParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlDbType DataType { get; set; }

        public StoredProcedureParameter() { }

        public static StoredProcedureParameter StringParam(string name, string value)
        {
            return new StoredProcedureParameter
            {
                Name = name,
                Value = value,
                DataType = SqlDbType.NVarChar,
            };
        }

        public static StoredProcedureParameter GuidParam(string name, Guid value)
        {
            return new StoredProcedureParameter
            {
                Name = name,
                Value = value,
                DataType = SqlDbType.UniqueIdentifier,
            };
        }

        public static StoredProcedureParameter IntParam(string name, int value)
        {
            return new StoredProcedureParameter
            {
                Name = name,
                Value = value,
                DataType = SqlDbType.Int,
            };
        }

        public static StoredProcedureParameter DecimalParam(string name, decimal value)
        {
            return new StoredProcedureParameter
            {
                Name = name,
                Value = value,
                DataType = SqlDbType.Decimal,
            };
        }
    }
}
