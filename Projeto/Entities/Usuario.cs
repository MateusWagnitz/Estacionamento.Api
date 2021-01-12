using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingModel
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade
        {
            get
            {
                if (DateTime.Now.Month >= DataNascimento.Month && DateTime.Now.Day >= DataNascimento.Day)
                    return DateTime.Now.Year - DataNascimento.Year;
                else
                    return DateTime.Now.Year - DataNascimento.Year - 1;
            }
        }

        public List<Carro> Carros { get; set; }
    }
}
