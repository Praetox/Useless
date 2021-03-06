using System;
using System.Collections.Generic;
using System.Text;

namespace pTib_FTP
{
    class MAdr
    {
        #region Character pointers // Diff 8.00->8.10 == 50A0
        public const int CH_ID = 0x613B70; //60EAD0 - 50A0
        public const int CH_HP = 0x613B6C; //60EACC - 50A0
        public const int CH_Ma = 0x613B50; //60EAB0 - 50A0
        public const int CH_Cap = 0x613B40; //60EAA0 - 50A0
        public const int CH_Lvl = 0x613B60; //60EAC0 - 50A0
        public const int CH_Exp = 0x613B64; //60EAC4 - 50A0
        public const int CH_Sol = 0x613B48; //60EAA8 - 50A0
        public const int CH_Mlv = 0x613B5C; //60EABC - 50A0
        public const int CH_Clk = 0x76BEF8; //766E58 - ?
        public const int CH_TSt = 0x76D4F8; //768458 - ?
        public const int CH_TTi = 0x76D4F4; //768454 - ?
        public const int CH_Con = 0x76C2C8; //766DF8 - 54D0
        public const int CH_Sta = 0x613B44; //60EAA4 - 50A0
        public const int CH_X = 0x61E9C8; //6198F8 - wtf?
        public const int CH_Y = 0x613BB0; //6198F4 - wtf?
        public const int CH_Z = 0x613C9C; //6198F0 - wtf?
        public const int CH_gX = 0x613BB4; //60EB14
        public const int CH_gY = 0x613BB0; //60EB10
        public const int CH_gZ = 0x613BAC; //60EB0C

        public const int CH_S0 = 0x616FF4;     //Ammo
        public const int CH_S1 = 0x616F88;     //Head
        public const int CH_S2 = 0x616FAC;     //Armor
        public const int CH_S3 = 0x616FB8;     //Right
        public const int CH_S4 = 0x616FC4;     //Left
        public const int CH_S5 = 0x616FD0;     //Legs
        public const int CH_S6 = 0x616FDC;     //Feet
        public const int CH_S7 = 0x616F94;     //Amulet
        public const int CH_S8 = 0x616FE8;     //Ring

        public const int CH_SkillL1 = 0x613B18; //60EA78
        public const int CH_SkillP1 = 0x613AFC; //60EA5C
        public const int CH_SkillL2 = 0x613B1C;
        public const int CH_SkillP2 = 0x613B00;
        public const int CH_SkillL3 = 0x613B20;
        public const int CH_SkillP3 = 0x613B04;
        public const int CH_SkillL4 = 0x613B24;
        public const int CH_SkillP4 = 0x613B08;
        public const int CH_SkillL5 = 0x613B28;
        public const int CH_SkillP5 = 0x613B0C;
        public const int CH_SkillL6 = 0x613B2C;
        public const int CH_SkillP6 = 0x613B10;
        public const int CH_SkillL7 = 0x613B30;
        public const int CH_SkillP7 = 0x613B14;


        #endregion
        #region Battelist pointers
        public const int BL_Start = 0x60EB34;
        public const int BL_Dist = 0xA0;
        public const int BL_End = BL_Start + (147 * BL_Dist);
        public const int BL_ID = -4;
        public const int BL_Name = 0;
        public const int BL_X = 32;
        public const int BL_Y = 36;
        public const int BL_Z = 40;
        public const int BL_Wlk = 72;
        public const int BL_Dir = 76;
        public const int BL_OFit = 92;
        public const int BL_HP = 132;
        public const int BL_Spd = 136;
        public const int BL_Vis = 140;
        public const int BL_LStr = 116;
        public const int BL_LCol = 120;
        #endregion
        #region Outfit IDs
        public const int OFit_Invis = 0;
        public const int OFit_GM = 75;
        public const int OFit_Druid = 128;
        public const int OFit_Pally = 129;
        public const int OFit_Sorc = 130;
        public const int OFit_Knight = 131;
        #endregion
        #region Container values
        public const int CT_Start = 0x617000;          //Start of first container
        public const int CTD_Container = 492;             //Distance between containers
        public const int CTD_ContainerID = 4;             //Container ID
        public const int CTD_ItemDist = 12;               //Distance between items
        public const int CTD_ContainerName = 16;          //
        public const int CTD_ContainerMax = 48;           //Max items in container
        public const int CTD_ContainerCurrent = 56;       //Amount of items in container
        public const int CTD_ItemID = 60;                 //Item ID
        public const int CTD_ItemCount = 64;              //Amount of stacked items
        #endregion
        #region Map values
        public const int Map_Ptr = 0x61E408;
        public const int Map_Tiles = 2015;
        public const int Map_TileDist = 172;
        public const int Map_ObjectDist = 12;
        public const int Map_ObjectIdDist = 0;
        public const int Map_ObjectDataDist = 4;
        public const int Map_ObjectIdOffset = 4;
        public const int Map_ObjectDataOffset = 8;
        public const int Map_Levelspy_Nop = 0x4C4320;       //writeNops 2; 2BC1 SUB EAX, ECX
        public const int Map_Levelspy_Above = 0x4C431C;     //B8 07 MOV EAX, 7
        public const int Map_Levelspy_Below = 0x4C4324;     //B8 02 MOV EAX, 2
        public const int Map_Levelspy_VlNop = 0xC12B;       //integer 2 bytes; 2BC1 SUB EAX, ECX
        public const int Map_Levelspy_VlAbove = 0x7;        //B8 07 MOV EAX, 7
        public const int Map_Levelspy_VlBelow = 0x2;        //B8 02 MOV EAX, 2
        public const int Map_Levelspy_VlMin = 0x0;
        public const int Map_Levelspy_VlMax = 0x7;
        public const int Map_Levelspy_DefaultZ = 0x7;       //"Ground" level
        public const int Map_Namespy_Nop1 = 0x4DD2D7;       //writeNops 2 bytes; 75 4C JNZ SHORT
        public const int Map_Namespy_Nop2 = 0x4DD2E1;       //writeNops 2 bytes; 75 42 JNZ SHORT
        public const int Map_Namespy_VlNop1 = 0x4C75;       //integer 2 bytes; 75 4C JNZ SHORT
        public const int Map_Namespy_VlNop2 = 0x4275;       //integer 2 bytes; 75 42 JNZ SHORT
        #endregion
        #region Tile IDs
        public const int Tile_Ladder_Hole = 411;
        public const int Tile_Transparent = 470;
        public const int Tile_Water_Old = 865;
        public const int Tile_Water_Fish_Begin = 4597;
        public const int Tile_Water_Fish_End = 4602;
        public const int Tile_Water_NoFish_Begin = 4603;
        public const int Tile_Water_NoFish_End = 4614;
        #endregion
        #region Other values
        public const int ID_Look = 0x766EA0;
        public const int ID_Click = 0x766E94;
        public const int WM_KD = 256;
        public const int WM_KU = 257;
        public const int BOX_1 = 0x60EA94;
        public const int BOX_2 = 0x60EA98;
        public const int BOX_3 = 0x60EA9C;
        public const int Gw_Time = 0x6198CC;
        public const int Ru_Explo = 0xC80;
        public const int Ru_GFB = 0xC77;
        public const int Ru_HMM = 0xC7E;
        public const int Ru_IH = 0xC50;
        public const int Ru_SD = 0xC53;
        public const int Ru_UH = 0xC58;
        public const int Ru_NE = 0xC4B;
        #endregion
        #region Item IDs
        public const int Item_Gold = 0xBD7;
        public const int Item_Rope = 0xBBB;
        public const int Food_Fish = 0xDFA;
        #endregion
    }
}
