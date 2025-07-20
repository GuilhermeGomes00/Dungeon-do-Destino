using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Text_Game.Cont
{
    public abstract class EquipamentosBase
    {
        public string NomeArma { get; set; }
        public string TipoDano { get; set; }
        public bool Magico { get; set; }
        public string Descricao { get; set; }
        public int? Municao { get; set; } // Para armas que usam munição, como arcos e flechas.
        public int? Mana { get; set; } // Para armas mágicas que consomem mana.
        public bool Shield { get; set; }

        public virtual int RolarDano(int? Adicional = null) => Dice.Roll(1, 4) + (Adicional ?? 0);

        public virtual int Atacar(int BonusAtaque, int InimigoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return RolarDano() + RolarDano();
            }

            if (rolagem + BonusAtaque >= InimigoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return RolarDano();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class GreatSword : EquipamentosBase
    {
        public GreatSword()
        {
            NomeArma = "Espada Larga";
            TipoDano = "Cortante";
            Magico = false;
            Descricao = "Uma espada extremamente grande, uma verdadeira prova de força ao conseguir usa-la.";
        }

        public override int RolarDano(int? Adicional = null)
        {
            return Dice.Roll(2, 5) + Dice.Roll(2, 5) + (Adicional ?? 0);
        }
    }

    public class LongBow : EquipamentosBase
    {
        public LongBow()
        {
            NomeArma = "Arco Longo";
            TipoDano = "Perfurante";
            Magico = false;
            Descricao = "Um arco longo feito de madeira resistente.";
            Municao = Dice.Roll(3, 18) + 13;
        }

        public override int RolarDano(int? Adicional = null)
        {
            return Dice.Roll(1, 8) + (Adicional ?? 0);
        }

        public int AtacarBOW(int BonusAtaque, int InimigoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return RolarDano() + RolarDano();
            }

            if (rolagem + BonusAtaque + 2 >= InimigoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return RolarDano();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class ShortSword : EquipamentosBase
    {
        public ShortSword()
        {
            NomeArma = "Espada Curta";
            TipoDano = "Cortante";
            Magico = false;
            Descricao = "Uma espada leve e fácil de manejar.";
        }

        public override int RolarDano(int? Adicional = null)
        {
            return Dice.Roll(1, 6) + (Adicional ?? 0);
        }

        public override int Atacar(int BonusAtaque, int InimigoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem >= 19)
            {
                Console.WriteLine("Crítico!");
                return RolarDano() + RolarDano();
            }

            if (rolagem + BonusAtaque >= InimigoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return RolarDano();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class Dagger : EquipamentosBase
    {
        public Dagger()
        {
            NomeArma = "Adaga";
            TipoDano = "Perfurante";
            Magico = false;
            Descricao = "Uma adaga pequena e afiada, sempre podendo ser útil a qualquer um.";
        }

        public override int RolarDano(int? Adicional = null)
        {
            return Dice.Roll(1, 4) + (Adicional ?? 0);
        }
    }

    public class ArcaneStaff : EquipamentosBase
    {
        public ArcaneStaff()
        {
            NomeArma = "Cajado Arcano";
            TipoDano = "Contundente";
            Magico = true;
            Descricao = "Um cajado mágico que canaliza energia arcana.";
            Mana = Dice.Roll(1, 4) + 1; // Exemplo de mana inicial
        }

        // Truques Gélidos
        // Truque ranged (nao que importe)

        public int RayOFrostDAMAGE(int? Adicional = null)
        {
            return Dice.Roll(2, 8) + (Adicional ?? 0);
        }

        public int AtacarROF(int BonusAtaque, int InimigoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return RayOFrostDAMAGE() + RayOFrostDAMAGE();
            }

            if (rolagem + BonusAtaque >= InimigoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return RayOFrostDAMAGE();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }

        // Truque melee

        public int FreezingTouchDAMAGE(int? Adicional = null)
        {
            return Dice.Roll(1, 6) + (Adicional ?? 0);
        }

        public int AtacarFT(int BonusAtaque, int InimigoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem >= 19)
            {
                Console.WriteLine("Crítico!");
                return FreezingTouchDAMAGE() + FreezingTouchDAMAGE();
            }

            if (rolagem + BonusAtaque >= InimigoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return FreezingTouchDAMAGE();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }

        // ataque melee que irá ter custo e pedir uma salva guarda
        public int CyroMortemDAMAGE(int? adicional = null)
        {
            return Dice.Roll(4, 20) + (adicional ?? 0);
        }

        public int AtacarCM(int InimigoDEX, int DC)
        {
            if (Mana > 0)
            {
                int rolagem = Dice.Roll(1, 20);
                Mana--; // Consome 1 ponto de mana para o ataque

                if ((rolagem + InimigoDEX) >= DC)
                {
                    Console.WriteLine("Acerto parcial");
                    return CyroMortemDAMAGE() / 2;
                }
                else
                {
                    Console.WriteLine("Acerto em cheio");
                    return CyroMortemDAMAGE();
                }
            }else
            {
                Console.WriteLine("Mana insuficiente para realizar o ataque.");
                return 0;
            }
            
        }

    }

    // =====================================================
    // Armas especiais

    public class SunBlade : EquipamentosBase
    {
        public SunBlade()
        {
            NomeArma = "Lâmina do Sol";
            TipoDano = "Cortante e Radiante";
            Magico = true;
            Descricao = "Uma espada mágica que brilha com a luz do sol.";
        }

        public override int RolarDano(int? Adicional = null)
        {
            return Dice.Roll(1, 10) + (Adicional ?? 0) + 2;
        }

        public override int Atacar(int InimigoAC, int BonusAtaque = 2)
        {
            return base.Atacar(BonusAtaque, InimigoAC);
        }
    }

    // Pedir para gepeto fazer um cajado arcano raro.
}






