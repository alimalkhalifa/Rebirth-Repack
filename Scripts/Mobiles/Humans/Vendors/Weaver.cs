using System;
using Server;
using Server.Items;
using Server.Misc;
using System.Collections; using System.Collections.Generic;

namespace Server.Mobiles
{
	public class Weaver : BaseVendor
	{
		private System.Collections.ArrayList m_SBInfos = new System.Collections.ArrayList();
		protected override System.Collections.ArrayList SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.TailorsGuild; } }
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBWeaver() );
		}

		[Constructable]
		public Weaver() : base( "the weaver" )
		{
			Job = JobFragment.weaver;
			Karma = Utility.RandomMinMax( 13, -45 );

			
			SetSkill( SkillName.Tactics, 25, 47.5 );
			SetSkill( SkillName.MagicResist, 25, 47.5 );
			SetSkill( SkillName.Parry, 25, 47.5 );
			SetSkill( SkillName.Swords, 15, 37.5 );
			SetSkill( SkillName.Macing, 15, 37.5 );
			SetSkill( SkillName.Fencing, 15, 37.5 );
			SetSkill( SkillName.Wrestling, 15, 37.5 );
			SetSkill( SkillName.Tailoring, 35, 57.5 );

		}

		public override void InitBody()
		{
			SetStr( 36, 50 );
			SetDex( 51, 65 );
			SetInt( 31, 45 );
			Hue = Utility.RandomSkinHue();
			SpeechHue = Utility.RandomDyedHue();

			Female = Utility.RandomBool();
			Body = Female ? 401 : 400;
			Name = NameList.RandomName( Female ? "female" : "male" );
		}

		public override void InitOutfit()
		{
			Item item = null;
			if ( !Female )
			{
				item = AddRandomHair();
				item.Hue = Utility.RandomHairHue();
				item = AddRandomFacialHair( item.Hue );
				item = new Shirt();
				item.Hue = Utility.RandomNondyedHue();
				AddItem( item );
				item = new ShortPants();
				item.Hue = Utility.RandomNondyedHue();
				AddItem( item );
				item = Utility.RandomBool() ? (Item)new Shoes() : (Item)new Sandals();
				item.Hue = Utility.RandomNeutralHue();
				AddItem( item );
				PackGold( 15, 100 );
			} else {
				item = AddRandomHair();
				item.Hue = Utility.RandomHairHue();
				item = new Shirt();
				item.Hue = Utility.RandomNondyedHue();
				AddItem( item );
				item = new Skirt();
				item.Hue = Utility.RandomNondyedHue();
				AddItem( item );
				item = Utility.RandomBool() ? (Item)new Shoes() : (Item)new Sandals();
				AddItem( item );
				PackGold( 15, 100 );
			}
		}

		public Weaver( Serial serial ) : base( serial )
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

