﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public interface Registrable
    {
        int getId();
        string getNombre();
        string getTipo();
    }
}
