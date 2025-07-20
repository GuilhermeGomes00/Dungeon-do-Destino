using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Game.Cont
{

    // Guerreiro:
    // 
    public class Guerreiro : PersonagemBase
    {
        public int SecondWindUSES { get; set; } = 2; // Usos de Second Wind

        public Guerreiro(string nome) : base(nome, 4, 2, 0, 3, 18, false, "Guerreiro", new GreatSword(), null)
        {
        }
        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(2, 10) + 10 + (CON*4) + 6;
        }

        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 3;
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }

        public void secondWind()
        {
            int curaSW = Dice.Roll(1, 10) + CON;
            if (SecondWindUSES > 0)
            {
                HP += curaSW;
                if (HP > HP_MAX) HP = HP_MAX;
                SecondWindUSES--;
                Console.WriteLine($"{Nome} usou Second Wind e curou {curaSW} pontos de vida!");
            }
            else
            {
                Console.WriteLine($"{Nome} não tem mais usos de Second Wind!");
            }
        }
        public override bool Fugir(int DC)
        {
            int roll = Dice.Roll(1, 20) + DEX;
            if (roll >= DC)
            {
                Console.WriteLine($"{Nome} conseguiu fugir com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine($"{Nome} falhou na tentativa de fuga.");
                return false;
            }
        }

        // Possivelmente implementar "pontos de ação", para mais ataques
    }

    // Arqueiro:

    public class Arqueiro : PersonagemBase
    {
        public override int BonusResistencia => 3;
        public int Mana { get; set; } = Dice.Roll(1, 4); // Mana inicial do Arqueiro
        public Arqueiro(string nome) : base(nome, 0, 4, 2, 2, 16, false, "Arqueiro", new LongBow(), new ShortSword())
        {
        }

        public override bool Fugir(int DC)
        {
            int roll = Dice.Roll(1, 20) + DEX + 3;
            if (roll >= DC)
            {
                Console.WriteLine($"{Nome} conseguiu fugir com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine($"{Nome} falhou na tentativa de fuga.");
                return false;
            }
        }

        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(2, 16) + 8 + (CON * 3) + 4;
        }

        // Possivel implementar mais habilidades

        public int SharpShooterDAMAGE()
        {
            return Dice.Roll(1, 8) + DEX + 6; // Dano do ataque de precisão
        }
        public int SharpShooterATTACK(int BonusAtaque, int InimigoAC)
        {
            int CustoMana = 1;
            if (Mana >= CustoMana)
            {
                int rolagem = Dice.Roll(1, 20);

                if (rolagem == 20)
                {
                    Console.WriteLine("Crítico!");
                    return SharpShooterDAMAGE() + SharpShooterDAMAGE();
                }

                if (rolagem + BonusAtaque + 2 - 4 >= InimigoAC)
                {
                    Console.WriteLine("Ataque bem sucedido!");
                    return SharpShooterDAMAGE();
                }

                Console.WriteLine("Errou o ataque...");
                return 0;
            }
            else
            {
                Console.WriteLine($"{Nome} não tem mana suficiente para realizar o ataque de precisão.");
                return 0; // Nenhum dano causado
            }
        }
    }
    // Mago: 

    public class Mago : PersonagemBase
        {
            public int Mana { get; set; } = Dice.Roll(2, 7); // Mana inicial do Mago
        public override int BonusResistencia => 3;
        public int DEFENSE { get; set; }
            public Mago(string nome) : base(nome, 0, 1, 4, 2, 14, false, "Mago", new ArcaneStaff(), new Dagger())
            {
            }
            public override bool Fugir(int DC)
            {
                int roll = Dice.Roll(1, 20) + DEX + INT;
                if (roll >= DC)
                {
                    Console.WriteLine($"{Nome} conseguiu fugir com sucesso!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{Nome} falhou na tentativa de fuga.");
                    return false;
                }
            }
            public override int GerarHP(int? ValorFixo = null)
            {
                return Dice.Roll(3, 12) + 6 + (CON * 2) + 3;
            }

            public override void ReceberDano(int dano)
            {
            
                if (DEFENSE > 0)
                {
                dano -= DEFENSE; // Reduz o dano recebido se o escudo estiver ativo
                if (dano < 0) dano = 0; // Evita dano negativo
                HP -= dano;
                }else
            {
                HP -= dano;
            }
            }

            // Possivelmente implementar mais feitiços e habilidades mágicas

            public void IceShield(int manaCost = 1)
            {
                if (Mana >= manaCost)
                {
                    Mana -= manaCost;
                    Console.WriteLine($"{Nome} conjurou um escudo mágico, reduzindo o dano recebido!");
                    DEFENSE = 5; // Reduz o dano recebido em 5 pontos
                }
                else
                {
                    Console.WriteLine($"{Nome} não tem mana suficiente para conjurar o escudo.");
                    // Nenhum dano reduzido
                }
            }
            public int ArcaneVitality(int manaCost = 2)
            {
                if (Mana >= manaCost)
                {
                    Mana -= manaCost;
                    int cura = Dice.Roll(1, 8) + INT; // Cura baseada na INT do Mago
                    HP += cura;
                    if (HP > HP_MAX) HP = HP_MAX;
                    Console.WriteLine($"{Nome} conjurou Arcane Vitality e curou {cura} pontos de vida!");
                    return cura;
                }
                else
                {
                    Console.WriteLine($"{Nome} não tem mana suficiente para conjurar Arcane Vitality.");
                    return 0; // Nenhum ponto de vida curado
                }
            }

        }
    
}
