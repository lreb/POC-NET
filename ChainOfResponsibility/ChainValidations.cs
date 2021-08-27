using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ChainValidations
    {
    }

    public class WordContainLetterA : Handler<CommonValidation>, IHandler<CommonValidation>
    {
        public override void Handle(CommonValidation validation)
        {
            if (validation.Word.Contains("a"))
            {
                throw new Exception($"Word {validation.Word}, contains  letter: a");
            }
            base.Handle(validation);
        }
    }

    public class WordContainLetterB : Handler<CommonValidation>, IHandler<CommonValidation>
    {
        public override void Handle(CommonValidation validation)
        {
            if (validation.Word.Contains("b"))
            {
                throw new Exception($"Word {validation.Word}, contains  letter: b");
            }
            base.Handle(validation);
        }
    }

    public class WordContainLetterC : Handler<CommonValidation>, IHandler<CommonValidation>
    {
        public override void Handle(CommonValidation validation)
        {
            if (validation.Word.Contains("c"))
            {
                throw new Exception($"Word {validation.Word}, contains  letter: c");
            }
            base.Handle(validation);
        }
    }
}
