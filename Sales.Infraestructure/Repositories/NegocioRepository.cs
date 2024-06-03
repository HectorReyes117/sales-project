﻿using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class NegocioRepository : Repository<Negocio>, INegocioRepository
{
    private readonly SalesContext _context;

    public NegocioRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}