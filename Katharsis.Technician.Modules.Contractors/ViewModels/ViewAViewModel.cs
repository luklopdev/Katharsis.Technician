﻿using Katharsis.Technician.Core;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katharsis.Technician.Modules.Contractors.ViewModels
{
    internal class ViewAViewModel : ViewModelBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
    }
}
