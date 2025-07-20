using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Game.Cont
{
    public class Zombie : PersonagemBase
    {
        public override int BonusResistencia => 2;
        public Zombie(string nome) : base(nome, 2, 0, 0, 3, 11, false, "Zumbi", null, null)
        {
        }

        public override bool Fugir(int DC)
        {
            return false;
        }

        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(2, 12) + 2 + (CON * 2);
        }
        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 1; // Zumbis têm uma defesa básica
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }

        // Dano e Ataques

        public int ClawsDAMAGE()
        {
            return Dice.Roll(1, 8) + STR; // Dano das garras do zumbi
        }
        public int ClawsATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);

            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return ClawsDAMAGE() + ClawsDAMAGE();
            }

            if (rolagem + STR + 2 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return ClawsDAMAGE();
            }

            Console.WriteLine("Errou o ataque...");
            return 0;
        }

        public int BiteDAMAGE()
        {
            return Dice.Roll(1, 6) + STR; // Dano da mordida do zumbi
        }
        public int BiteATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return BiteDAMAGE() + BiteDAMAGE();
            }
            if (rolagem + STR + 2 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return BiteDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class Skeleton : PersonagemBase
    {
        public override int BonusResistencia => 2;
        public Skeleton(string nome) : base(nome, 1, 3, 0, 2, 14, false, "Esqueleto", new LongBow(), null)
        {
        }
        public override bool Fugir(int DC)
        {
            return false;
        }
        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(2, 10) + 2 + (CON * 2);
        }
        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 1; // Esqueletos têm uma defesa básica
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }
        // Dano e Ataques
        public int SwordDAMAGE()
        {
            return Dice.Roll(1, 8) + STR; // Dano da espada do esqueleto
        }
        public int SwordATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return SwordDAMAGE() + SwordDAMAGE();
            }
            if (rolagem + STR + 2 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return SwordDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class Mimic : PersonagemBase
    {
        public override int BonusResistencia => 3;
        public Mimic(string nome = "Mimico") : base(nome, 3, 2, 0, 3, 13, false, "Mímico", null, null)
        {
        }
        public override bool Fugir(int DC)
        {
            return false;
        }
        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(5, 30) + 4 + (CON * 2);
        }
        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 2; // Mímicos têm uma defesa básica
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }
        // Dano e Ataques
        public int BiteDAMAGE()
        {
            return Dice.Roll(2, 8) + STR; // Dano da mordida do mímico
        }
        public int BiteATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return BiteDAMAGE() + BiteDAMAGE();
            }
            if (rolagem + STR + 3 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return BiteDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }

        public int SlamDAMAGE()
        {
            return Dice.Roll(2, 12) + STR; // Dano do golpe do mímico
        }
        public int SlamATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return SlamDAMAGE() + SlamDAMAGE();
            }
            if (rolagem + STR + 3 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return SlamDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }


    }

    public class VoidSoul : PersonagemBase
    {
        public override int BonusResistencia => 3;
        public VoidSoul(string nome = "Alma vazia") : base(nome, 1, 3, 4, 4, 15, false, "Alma do Vazio", null, null)
        {
        }
        public override bool Fugir(int DC)
        {
            return false;
        }
        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(2, 10) + 5 + (CON * 2);
        }
        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 3; // Alma do Vazio tem uma defesa básica
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }

        // Dano e Ataques
        public int PsychicScreamDAMAGE()
        {
            return Dice.Roll(1, 8) + Dice.Roll(1, 8) + Dice.Roll(1, 8); // Dano do grito psíquico
        }
        public int PsychicScreamSAVE(int SavingTrown)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem + SavingTrown >= 14)
            {
                Console.WriteLine("Sua mente resiste um pouco...");
                return PsychicScreamDAMAGE()/2; // Metade do dano se salvar
            }
            else
            {
                Console.WriteLine("Falhou no salvamento contra o grito psíquico!");
                return PsychicScreamDAMAGE();
            }
        }

        public int OldSpearDAMAGE()
        {
            return Dice.Roll(1, 6) + DEX + Dice.Roll(1, 4); // Dano da lança antiga
        }

        public int OldSpearATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return OldSpearDAMAGE() + OldSpearDAMAGE();
            }
            if (rolagem + DEX + 2 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return OldSpearDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }
    }

    public class SkeletonDragon : PersonagemBase
    {
        public override int BonusResistencia => 3;
        public SkeletonDragon(string nome = "Dragão Esqueleto") : base(nome, 5, 2, 0, 5, 17, false, "Dragão Esqueleto", null, null)
        {
        }
        public override bool Fugir(int DC)
        {
            return false;
        }
        public override int GerarHP(int? ValorFixo = null)
        {
            return Dice.Roll(6, 36) + 10 + (CON * 2);
        }
        public override void ReceberDano(int dano)
        {
            int danoFinal = dano - 4; // Dragão Esqueleto tem uma defesa básica
            if (danoFinal < 0) danoFinal = 0; // Evita dano negativo
            HP -= danoFinal;
        }
        // Dano e Ataques
        public int ClawDAMAGE()
        {
            return Dice.Roll(2, 6) + STR; // Dano da garra do dragão esqueleto
        }
        public int ClawATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return ClawDAMAGE() + ClawDAMAGE();
            }
            if (rolagem + STR + 3 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return ClawDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }
        public int BiteDAMAGE()
        {
            return Dice.Roll(2, 8) + Dice.Roll(1, 6) + STR; // Dano da mordida do dragão esqueleto
        }
        public int BiteATTACK(int alvoAC)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem == 20)
            {
                Console.WriteLine("Crítico!");
                return BiteDAMAGE() + BiteDAMAGE();
            }
            if (rolagem + STR + 3 >= alvoAC)
            {
                Console.WriteLine("Ataque bem sucedido!");
                return BiteDAMAGE();
            }
            Console.WriteLine("Errou o ataque...");
            return 0;
        }

        public int PutridBreathDAMAGE()
        {
            return Dice.Roll(3, 10) + STR; // Dano do sopro de fogo
        }
        public int PutridBreathSAVE(int SavingTrown)
        {
            int rolagem = Dice.Roll(1, 20);
            if (rolagem + SavingTrown >= 16)
            {
                Console.WriteLine("Você conseguiu resistir ao sopro podre!");
                return PutridBreathDAMAGE() / 2; // Metade do dano se salvar
            }
            else
            {
                Console.WriteLine("Falhou no salvamento contra o sopro podre!");
                return PutridBreathDAMAGE();
            }
        }
    }
}
