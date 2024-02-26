﻿namespace NetCoreMVC.Models.Entities;

public class DbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string UsersCollection { get; set; } = string.Empty;
}
