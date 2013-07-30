using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL2.ActiveRecord.Example
{
    [ActiveRecord(Schema = "UA_APPLICATION", Table = "TB_ALUNO")]
    public class Student : ActiveRecordBase<Student>
    {
        [PrimaryKey(Generator = PrimaryKeyType.Increment, Column = "ID_ALUNO")]
        public long Id { get; set; }

        [Property(Column = "DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Property(NotNull = true, Column = "NM_NOME")]
        public string Nome { get; set; }

        [Property]
        public string SobreNome { get; set; }

        [Property(Length = 1000000, Column = "DS_DESCRICAO")]
        public string Descricao { get; set; }

        // Descomente para ver o script de atualização do banco de dados após criar o schema 
        //[Property(Length = 1000000, Column = "VL_DESCRICAO")]
        //public decimal Salario { get; set; }
    }
}
