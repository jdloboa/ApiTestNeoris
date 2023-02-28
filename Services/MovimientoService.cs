using DataAccess.Repositories;
using DTO.Request;
using DTO.Response;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovimientoService : IMovimientoService
    {

        private readonly IMovimientoRepository _repository;

        public MovimientoService(IMovimientoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Movimiento> add(MovimientoDtoRequest movimiento)
        {
            return await _repository.add(new Movimiento
            {
                fecha = movimiento.fecha,
                tipoMovimiento = movimiento.tipoMovimiento,
                valor= movimiento.valor,
                cuentaID = movimiento.cuentaID               
            });
        }

        public async Task delete(int movimientoId)
        {
            await _repository.delete(movimientoId);
        }

        public async Task<MovimientoDtoResponse> getById(int movimientoId)
        {
            var movimiento = await _repository.getById(movimientoId);
            if (movimiento == null)
                return null;
            return new MovimientoDtoResponse
            {
                movimientoId = movimiento.movimientoId,
                fecha = movimiento.fecha,
                tipoMovimiento = movimiento.tipoMovimiento,
                valor = movimiento.valor,
                saldo = movimiento.cuenta.saldoActual,
                cuentaID = movimiento.cuentaID,
                numeroCuenta = movimiento.cuenta.numeroCuenta,
                tipoCuenta = movimiento.cuenta.tipoCuenta,
                clienteId = movimiento.cuenta.clienteId,
                nombreCliente = movimiento.cuenta.cliente.nombre   
            };
        }

        public async Task<List<MovimientoDtoResponse>> listAsync()
        {
            var collection = await _repository.listAsync();

            return collection.Select(movimiento => new MovimientoDtoResponse
            {
                movimientoId = movimiento.movimientoId,
                fecha = movimiento.fecha,
                tipoMovimiento = movimiento.tipoMovimiento,
                valor = movimiento.valor,
                saldo = movimiento.cuenta.saldoActual,
                cuentaID = movimiento.cuentaID,
                numeroCuenta = movimiento.cuenta.numeroCuenta,
                tipoCuenta = movimiento.cuenta.tipoCuenta,
                clienteId = movimiento.cuenta.clienteId,
                nombreCliente = movimiento.cuenta.cliente.nombre
            })
             .ToList();
        }

        public async Task<Movimiento> update(int idMovimiento, MovimientoDtoRequest movimiento)
        {
            return await _repository.update(new Movimiento
            {
                movimientoId = idMovimiento,
                fecha = movimiento.fecha,
                tipoMovimiento = movimiento.tipoMovimiento,
                valor = movimiento.valor,
                cuentaID = movimiento.cuentaID
            });
        }

        public async Task<List<MovimientoDtoResponse>> generarReportePorClienteYFecha(int clienteId, DateTime fechaInicial, DateTime fechaFinal)
        {
            var movimientos = await _repository.generarReportePorClienteYFecha(clienteId, fechaInicial, fechaFinal);
            return movimientos.Select(movimiento => new MovimientoDtoResponse
            {
                movimientoId = movimiento.movimientoId,
                fecha = movimiento.fecha,
                tipoMovimiento = movimiento.tipoMovimiento,
                valor = movimiento.valor,
                saldo = movimiento.cuenta.saldoActual,
                cuentaID = movimiento.cuentaID,
                numeroCuenta = movimiento.cuenta.numeroCuenta,
                tipoCuenta = movimiento.cuenta.tipoCuenta,
                clienteId = movimiento.cuenta.clienteId,
                nombreCliente = movimiento.cuenta.cliente.nombre
            })
             .ToList();
        }
    }
}
