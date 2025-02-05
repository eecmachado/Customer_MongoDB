﻿namespace Store.Infra.MongoDB.DataModels;

public class AddressData
{
    public string? Street { get; set; }

    public string? Number { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }
}