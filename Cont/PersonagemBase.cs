using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Game.Cont
{
    interface IAtacavel
    {
        void ReceberDano(int dano);
    }

    public abstract class PersonagemBase : IAtacavel
    {

        public string Nome { get; }
        public int STR { get; set; }
        public int DEX { get; set; }
        public int CON { get; set; }
        public int INT { get; set; }
        public virtual int BonusResistencia { get; } = 3;
        public int AC { get; set; }
        public int HP { get; set; }
        private int _hpMax;
        public int HP_MAX => _hpMax;
        public bool WithShield { get; set; }
        public string? CLASSE { get; set; }
        public EquipamentosBase? Arma { get; set; } = null; // Arma equipada
        public EquipamentosBase? Arma2 { get; set; } = null; // Arma secundária
        public int QuantidadePocoes { get; set; } = Dice.Roll(1, 3) + 2;

        // -----------------------------------------------------------------

        public PersonagemBase(string NAME, int str, int dex, int _int, int con, int ac, bool withShield, string? _classe, EquipamentosBase? arma, EquipamentosBase? arma2)
        {
            Nome = NAME;
            STR = str;
            DEX = dex;
            INT = _int;
            CON = con;
            AC = ac;
            WithShield = withShield;
            HP = GerarHP();
            _hpMax = HP;
            CLASSE = _classe;
            Arma = arma;
            Arma2 = arma2;
        }

        // -----------------------------------------------------------------
        public abstract int GerarHP(int? ValorFixo = null); //Dice.Roll(min, max) + CON + x;

        public void UsarPocaoDeCura()
        {
            if (QuantidadePocoes > 0)
            {
                int cura = Dice.rng.Next(4, 12) + 2;
                HP += cura;
                if (HP > HP_MAX) HP = HP_MAX;
                QuantidadePocoes--;
            }
            else
            {
                Console.WriteLine("Você não tem mais poções.");
            }
        }

        public bool IsLive()
        {
            if (this.HP >= 1) return true; else return false;
        }

        public virtual void ReceberDano(int dano)
        {
            int danofinal;
            this.HP -= dano;
            Console.WriteLine($"{Nome} foi atingindo e recebeu {dano} pontos de dano.");
        }

        public abstract bool Fugir(int DC);
    }
}
