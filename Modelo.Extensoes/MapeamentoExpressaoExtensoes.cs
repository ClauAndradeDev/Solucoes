using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Extensoes
{
    public static class MapeamentoExpressaoExtensoes
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllOtherMembers(opt => opt.Ignore());
            return expression;
        }
    }
}
