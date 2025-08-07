using System.ComponentModel;

namespace GestaoEstoque.Models.Enums
{
    public enum OrderStatusEnum
    {
        [Description("Em Análise")]
        EmAnalise = 1,

        [Description("Em Processamento")]
        EmProcessamento = 2,

        [Description("Enviado")]
        Enviado = 3,

        [Description("Entregue")]
        Entregue = 4,
    }
}