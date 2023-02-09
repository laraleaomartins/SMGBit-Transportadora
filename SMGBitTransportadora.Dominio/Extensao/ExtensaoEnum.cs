using SMGBitTransportadora.Dominio.Enums;

namespace SMGBitTransportadora.Dominio.Extensao
{
    public static class ExtensaoEnum
    {
        public static TipoVeiculoEnum StringParaTipoVeiculoEnum(this string stringJson)
        {
            switch (stringJson.ToLower())
            {
                case "truck":
                    return TipoVeiculoEnum.Truck;
                case "vuc":
                    return TipoVeiculoEnum.Vuc;
                case "carreta":
                    return TipoVeiculoEnum.Carreta;
                case "van":
                    return TipoVeiculoEnum.Van;
                default:
                    return TipoVeiculoEnum.NaoRegistrado;
            }

        }

        public static string TipoVeiculoEnumParaString(this TipoVeiculoEnum tipoVeiculo)
        {
            switch (tipoVeiculo)
            {
                case TipoVeiculoEnum.Truck:
                    return "Truck";
                case TipoVeiculoEnum.Vuc:
                    return "Vuc";
                case TipoVeiculoEnum.Carreta:
                    return "Carreta";
                case TipoVeiculoEnum.Van:
                    return "Van";
                default:
                    return "Não registrado";
            }

        }

        public static TipoViagemEnum StringParaTipoViagemEnum(this string stringJson)
        {
            switch (stringJson.ToLower())
            {
                case "last mile":
                    return TipoViagemEnum.LastMile;
                case "fullfilment":
                    return TipoViagemEnum.Fullfilment;
                default:
                    return TipoViagemEnum.NaoRegistrado;
            }

        }

        public static string TipoViagemEnumParaString(this TipoViagemEnum tipoViagem)
        {
            switch (tipoViagem)
            {
                case TipoViagemEnum.LastMile:
                    return "Last mile";
                case TipoViagemEnum.Fullfilment:
                    return "Fullfilment";
                default:
                    return "Não registrado";
            }
        }
    }
}
