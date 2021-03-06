﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class GradoPublicacion
    {
        public int id{get; set;}
        public string nivel { get; set; }
        public Nullable<float> comision { get; set; }
        public Nullable<DateTime> bajaLogica { get; set; }

        public override string ToString()
        {
            return this.nivel;
        }

        public override bool Equals(object obj)
        {
            try
            {
                GradoPublicacion grado = (GradoPublicacion)obj;
                return grado.id.Equals(this.id);
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
