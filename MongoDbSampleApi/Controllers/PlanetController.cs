﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDbSampleApi.Extensions;
using MongoDbSampleApi.Models.FilterModels;
using MongoDbSampleApi.Models.RestModels;
using MongoDbSampleApi.Services;

namespace MongoDbSampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetController : ControllerBase
{
    private readonly IPlanetService planetService;
    
    public PlanetController(IPlanetService planetService)
    {
        this.planetService = planetService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(ObjectId id)
        => (await planetService.GetAsync(id)).CreateActionResult();

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync(PlanetFilterModel planetFilterModel)
        => (await planetService.GetAllAsync(planetFilterModel)).CreateActionResult();
    
    [HttpPut]
    public async Task<IActionResult> AddAsync(PlanetRestModel planetRestModel)
    {
        await planetService.AddAsync(planetRestModel);
        return new OkResult();
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync(PlanetRestModel planetRestModel)
        => (await planetService.UpdateAsync(planetRestModel)).CreateActionResult();

    [HttpPost("updateAndGet")]
    public async Task<IActionResult> UpdateAndGetAsync(PlanetRestModel planetRestModel)
        => (await planetService.UpdateAndGetAsync(planetRestModel)).CreateActionResult();

    [HttpPost("updateAll")]
    public async Task<IActionResult> BatchUpdateAsync(IReadOnlyCollection<ObjectId> ids, PlanetRestModel updateModel)
        => (await planetService.BatchUpdateAsync(ids, updateModel)).CreateActionResult();

    [HttpPatch("patch")]
    public async Task<IActionResult> PatchAsync(PlanetRestModel planetRestModel)
        => (await planetService.PatchAsync(planetRestModel)).CreateActionResult();

    [HttpPatch("patchAndGet")]
    public async Task<IActionResult> PatchAndGetAsync(PlanetRestModel planetRestModel)
        => (await planetService.PatchAndGetAsync(planetRestModel)).CreateActionResult();

    [HttpDelete]
    public async Task<IActionResult> BatchDeleteAsync(IReadOnlyCollection<ObjectId> ids)
        => (await planetService.BatchDeleteAsync(ids)).CreateActionResult();
}