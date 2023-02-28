using DataAccess.Repositories;
using DTO.Request;
using DTO.Response;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _repository;



        public CuentaService(ICuentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cuenta> add(CuentaDtoRequest cuenta)
        {

            return await _repository.add(new Cuenta
            {
                numeroCuenta = cuenta.numeroCuenta,
                tipoCuenta = cuenta.tipoCuenta,
                saldoInicial = cuenta.saldoInicial,
                estado = cuenta.estado,
                clienteId = cuenta.clienteId,
                saldoActual = cuenta.saldoInicial
            }) ;

        }

        public async Task delete(int cuentaId)
        {
            await _repository.delete(cuentaId);
        }

        public async Task<CuentaDtoResponse> getById(int cuentaId)
        {
            var cuenta = await _repository.getById(cuentaId);
            if (cuenta == null)
            {
                return null;
            }
            return new CuentaDtoResponse
            { 
                cuentaId = cuentaId,
                numeroCuenta=cuenta.numeroCuenta,
                tipoCuenta=cuenta.tipoCuenta,
                saldoInicial=cuenta.saldoInicial,
                estado=cuenta.estado,
                clienteId=cuenta.clienteId,
                nombreCliente=cuenta.cliente.nombre,
                identificacionCliente=cuenta.cliente.personaId,
                saldoActual=cuenta.saldoActual
            };
            
        }

        public async Task<List<CuentaDtoResponse>> listAsync()
        {
            var collection = await _repository.listAsync();

            return collection.Select(cuenta => new CuentaDtoResponse
            {
                cuentaId = cuenta.cuentaId,
                numeroCuenta = cuenta.numeroCuenta,
                tipoCuenta = cuenta.tipoCuenta,
                saldoInicial = cuenta.saldoInicial,
                estado = cuenta.estado,
                clienteId = cuenta.clienteId,
                identificacionCliente = cuenta.cliente.personaId,
                nombreCliente = cuenta.cliente.nombre,
                saldoActual = cuenta.saldoActual,
            })
             .ToList();
        }

        public async Task<Cuenta> update(int cuentaId, CuentaDtoRequest cuenta)
        {
            double saldoActual = 0;
            var cuentaAct = await _repository.getById(cuentaId);
            if(cuentaAct == null)
            {
                return null ;          
            }
            else
            {
                if (cuentaAct.saldoActual != null && cuentaAct.saldoActual > 0)
                {
                    saldoActual = cuentaAct.saldoActual;
                }
            }
            return await _repository.update(new Cuenta
            {
                cuentaId = cuentaId,
                numeroCuenta = cuenta.numeroCuenta,
                tipoCuenta = cuenta.tipoCuenta,
                saldoInicial = cuenta.saldoInicial,
                estado = cuenta.estado,
                clienteId = cuenta.clienteId,
                saldoActual = saldoActual
            });
        }
        public async Task<Cuenta> setSaldo(int cuentaId, double saldo) 
        {
            var cuenta = await _repository.getById(cuentaId);
            double saldoFinal = saldo + cuenta.saldoActual;
            if (saldoFinal < 0)
            {
                throw new Exception("Saldo no disponible");
            }
            if (saldoFinal >= 0)
            {
                cuenta.saldoActual = saldoFinal;
            }
            return  await _repository.update(cuenta);
        }
    }
}
