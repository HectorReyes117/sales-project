﻿using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;
using Sales.WebApp.Models.Usuario;
using UsuarioModel = Sales.WebApp.Models.Usuario.UsuarioModel;

namespace Sales.WebApp.Request;

public interface IUsuariosRequests
{
    Task<HttpResponseMessage> Save(UsuarioCreationViewModel product);
    Task<HttpResponseMessage> Update(UsuarioUpdateViewModel product);
    Task<UsuarioModel?> Get(int id);
    Task<List<UsuarioModel>> GetAll();
    Task<HttpResponseMessage> DeleteUser(int id);
}