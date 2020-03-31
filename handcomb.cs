using System;

namespace battle_of_cards_grupauderzeniowa
{
    public enum HandCombination 
    {cover,nothing, 
    pair_2, pair_3, pair_4, pair_5, pair_6, pair_7, pair_8, pair_9,pair_10, pair_J,pair_Q,pair_K,pair_A, 
    dpair_2, dpair_3, dpair_4, dpair_5, dpair_6, dpair_7, dpair_8, dpair_9,dpair_10, dpair_J,dpair_Q,dpair_K,dpair_A,
    triplets_2, triplets_3, triplets_4, triplets_5, triplets_6, triplets_7, triplets_8, triplets_9,triplets_10, triplets_J,triplets_Q,triplets_K,triplets_A, 
    straight_5, straight_6, straight_7, straight_8, straight_9, straight_10, straight_J, straight_Q,straight_K, straight_A,
    flush_6, flush_7, flush_8, flush_9,flush_10, flush_J,flush_Q,flush_K,flush_A, 
    full_2, full_3, full_4, full_5, full_6, full_7, full_8, full_9,full_10, full_J,full_Q,full_K,full_A, 
    quads_2, quads_3, quads_4, quads_5, quads_6, quads_7, quads_8, quads_9,quads_10, quads_J,quads_Q,quads_K,quads_A, 
    poker_5, poker_6, poker_7, poker_8, poker_9,poker_10, poker_J,poker_Q,poker_K, POKER}
}