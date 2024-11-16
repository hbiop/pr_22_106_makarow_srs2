using System;
using System.Collections.Generic;

namespace pr_22_106_makarow_srs2.Models.Entities;

public partial class Authorization
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Parol { get; set; } = null!;
}
