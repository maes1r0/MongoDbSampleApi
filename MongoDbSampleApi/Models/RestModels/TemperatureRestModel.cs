﻿using MongoDB.Bson;

namespace MongoDbSandbox.Models.RestModels;

public class TemperatureRestModel
{
    public ObjectId Id { get; set; }
    
    public double? Min { get; set; }
    
    public double? Max { get; set; }
    
    public double? Mean { get; set; }
}