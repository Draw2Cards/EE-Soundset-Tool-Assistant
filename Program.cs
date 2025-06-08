namespace EE_soundset_tool
{
    internal static class Program
    {
        public static List<Structure> Structures { get; set; } = new List<Structure>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Structures = new List<Structure>
            {
                new Structure("cd_action1",         1,  "i", "Action Acknowledgement 1"),
                new Structure("cd_action2",         2,  "j", "Action Acknowledgement 2"),
                new Structure("cd_action3",         3,  "k", "Action Acknowledgement 3"),
                new Structure("cd_action4",         4,  "s", "Action Acknowledgement 4"),
                new Structure("cd_action5",         5,  "t", "Action Acknowledgement 5"),
                new Structure("cd_action6",         6,  "u", "Action Acknowledgement 6"),
                new Structure("cd_action7",         7,  "v", "Action Acknowledgement 7"),
                new Structure("cd_action_rare1",    8,  "x", "Rare Action Acknowledgement 1*",  "* Though these are listed in the IDS files and elsewhere as selection sounds, these rare sound files are action sounds."),
                new Structure("cd_action_rare2",    9,  "y", "Rare Action Acknowledgement 2*",  "* Though these are listed in the IDS files and elsewhere as selection sounds, these rare sound files are action sounds."),
                new Structure("cd_action_rare3",    10, "a_", "Rare Action Acknowledgement 3*", "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_action_rare4",    11, "b_", "Rare Action Acknowledgement 4*", "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_attack1",         12, "c_", "Attack Sound 1*",                "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_attack2",         13, "d_", "Attack Sound 2*",                "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_attack3",         14, "e_", "Attack Sound 3*",                "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_attack4",         15, "f_", "Attack Sound 4*",                "* While you can assign attack sounds, party members will generally ignore these and use sounds attached to their weapon types, e.g. your PC will attack with a sword sound instead of using an attack sound from the soundset."),
                new Structure("cd_battlecry1",      16, "a", "Battle Cry 1"),
                new Structure("cd_battlecry2",      17, "8", "Battle Cry 2"),
                new Structure("cd_battlecry3",      18, "9", "Battle Cry 3"),
                new Structure("cd_battlecry4",      19, "g_", "Battle Cry 4"),
                new Structure("cd_battlecry5",      20, "h_", "Battle Cry 5"),
                new Structure("cd_bored1",          21, "d", "Bored"),
                new Structure("cd_bored2",          22, "i_", "Bored 2"),
                new Structure("cd_breaking_pt",     23, "j_", "Breaking Point"),
                new Structure("cd_city",            24, "o", "In City"),
                new Structure("cd_common1",         25, "f", "Selected 1"),
                new Structure("cd_common2",         26, "g", "Selected 2"),
                new Structure("cd_common3",         27, "h", "Selected 3"),
                new Structure("cd_common4",         28, "0", "Selected 4"),
                new Structure("cd_common5",         29, "k_", "Selected 5"),
                new Structure("cd_common6",         30, "l_", "Selected 6"),
                new Structure("cd_common7",         31, "m_", "Selected 7"),
                new Structure("cd_criticalhit",     32, "z", "Critical Hit"),
                new Structure("cd_criticalmiss",    33, "1", "Critical Miss"),
                new Structure("cd_damage1",         34, "l", "Being Hit"),
                new Structure("cd_damage2",         35, "n_", "Being Hit 2"),
                new Structure("cd_damage3",         36, "o_", "Being Hit 3"),
                new Structure("cd_day",             37, "q", "Daytime"),
                new Structure("cd_disrupted",       38, "6", "Spell Disrupted"),
                new Structure("cd_dungeon",         39, "p", "In Dungeon"),
                new Structure("cd_dying1",          40, "m", "Dying"),
                new Structure("cd_dying2",          41, "p_", "Dying 2"),
                new Structure("cd_forest",          42, "n", "In Forest"),
                new Structure("cd_gen_death1",      43, "w", "Reaction to Party Member Death"),
                new Structure("cd_gen_death2",      44, "q_", "Reaction to Party Member Death 2"),
                new Structure("cd_happy",           45, "r_", "Happy"),
                new Structure("cd_hurt1",           46, "e", "Badly Wounded"),
                new Structure("cd_hurt2",           47, "s_", "Badly Wounded 2"),
                new Structure("cd_immune",          48, "2", "Target Immune"),
                new Structure("cd_inventory",       49, "3", "Inventory Full"),
                new Structure("cd_leader1",         50, "b", "Becoming Leader"),
                new Structure("cd_leader2",         51, "t_", "Becoming Leader 2"),
                new Structure("cd_morale_break1",   52, "u_", "Morale Break 1"),
                new Structure("cd_morale_break2",   53, "v_", "Morale Break 2"),
                new Structure("cd_night",           54, "r", "Nighttime"),
                new Structure("cd_pickpocket",      55, "4", "Pickpocket Successful"),
                new Structure("cd_select_rare1",    56, "w_", "Rare Selected 1"),
                new Structure("cd_select_rare2",    57, "x_", "Rare Selected 2"),
                new Structure("cd_select_rare3",    58, "y_", "Rare Selected 3"),
                new Structure("cd_select_rare4",    59, "z_", "Rare Selected 4"),
                new Structure("cd_select_rare5",    60, "0_", "Rare Selected 5"),
                new Structure("cd_select_rare6",    61, "1_", "Rare Selected 6"),
                new Structure("cd_select_rare7",    62, "2_", "Rare Selected 7"),
                new Structure("cd_select_rare8",    63, "3_", "Rare Selected 8"),
                new Structure("cd_shadows",         64, "5", "Hide in Shadows Successful"),
                new Structure("cd_tired1",          65, "c", "Tired"),
                new Structure("cd_tired2",          66, "4_", "Tired 2"),
                new Structure("cd_trap",            67, "7", "Trap is Set Successfully"),
                new Structure("cd_unhappy_1",       68, "5_", "Unhappy"),
                new Structure("cd_unhappy_2",       69, "6_", "Unhappy 2"),
            };

            Application.Run(new Form1());
        }
    }
}