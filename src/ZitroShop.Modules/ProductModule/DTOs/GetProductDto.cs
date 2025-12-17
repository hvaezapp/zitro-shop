using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZitroShop.Modules.ProductModule.DTOs;

public record GetProductDto(long Id , string Name , decimal Price , bool IsSold , bool IsLocked);


