﻿using Microsoft.EntityFrameworkCore;

namespace A.S.A.S_Control_Escolar.Model.Response
{
    [Keyless]
    public class ResponseInsertarMaestroClase
    {
        public Int32? Rsp { get; set; }
        public string? Msg { get; set; }
    }
}
