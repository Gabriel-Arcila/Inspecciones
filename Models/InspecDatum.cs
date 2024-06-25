﻿using System;
using System.Collections.Generic;

namespace Inspecciones.Models
{
    public partial class InspecDatum
    {
        public int IdInsData { get; set; }
        public int IdMaqPre { get; set; }
        public int IdInspec { get; set; }
        public int Iddata { get; set; }
        public string Idobserv { get; set; } = null!;

        public virtual Inspeccion IdInspecNavigation { get; set; } = null!;
        public virtual ImaqPre IdMaqPreNavigation { get; set; } = null!;
    }
}
