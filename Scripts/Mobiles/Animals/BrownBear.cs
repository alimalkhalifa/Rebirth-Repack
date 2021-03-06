using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class BrownBear : BaseCreature
	{
		[Constructable]
		public BrownBear() : base( AIType.AI_Melee, FightMode.Agressor, 10, 1, 0.45, 0.8 )
		{
			Body = 211;
			Name = "a brown bear";
			Hue = 443;
			SetStr( 76, 100 );
			SetHits( 76, 100 );
			SetDex( 26, 45 );
			SetStam( 56, 75 );
			SetInt( 23, 47 );
			SetMana( 0 );

			Tamable = true;
			MinTameSkill = 55;
			BaseSoundID = 95;
			SetSkill( SkillName.Tactics, 40.1, 60 );
			SetSkill( SkillName.Wrestling, 40.1, 60 );
			SetSkill( SkillName.Parry, 37.6, 55 );
			SetSkill( SkillName.MagicResist, 25.1, 35 );

			VirtualArmor = 12;
			SetDamage( 5, 13 );
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public override int GenerateFurs(Corpse c)
		{
			c.DropItem( new DarkFur() );
			return 1;
		}

		public BrownBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}

