﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.Core.Domain.Common.Models;

public class BasePageableModel
{
    public int Index { get; set; }          
    public int Size { get; set; }           
    public int Count { get; set; }          
    public int Pages { get; set; }          

    public bool HasPrevious => Index > 1;
    public bool HasNext => Index < Pages;
}