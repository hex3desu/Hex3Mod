﻿using BepInEx;
using BepInEx.Configuration;
using R2API;
using R2API.Utils;
using RoR2;
using System;
using UnityEngine;
using Hex3Mod;
using Hex3Mod.Logging;
using Hex3Mod.HelperClasses;

namespace Hex3Mod.Items
{
    /*
    ATG Prototype is a simple port of the ATG to the Common tier, but with a different proc condition.
    It should serve a different purpose than the normal ATG (Consistent, small damage rather than luck-based, large damage) and also give ICBM a good Common item to synergize with
    */
    public class AtgPrototype
    {
        // Create functions here for defining the ITEM, TOKENS, HOOKS and CONFIG. This is simpler than doing it in Main
        static string itemName = "AtgPrototype"; // Change this name when making a new item
        static string upperName = itemName.ToUpper();
        public static ItemDef itemDefinition = CreateItem(); // Must be public for ScatteredReflection to read
        public static GameObject LoadPrefab()
        {
            GameObject pickupModelPrefab = Main.MainAssets.LoadAsset<GameObject>("Assets/Models/Prefabs/ATGPrototypePrefab.prefab");
            return pickupModelPrefab;
        }
        public static Sprite LoadSprite()
        {
            Sprite pickupIconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Icons/ATGPrototype.png");
            return pickupIconSprite;
        }
        public static ItemDef CreateItem()
        {
            ItemDef item = ScriptableObject.CreateInstance<ItemDef>();

            item.name = itemName;
            item.nameToken = "H3_" + upperName + "_NAME";
            item.pickupToken = "H3_" + upperName + "_PICKUP";
            item.descriptionToken = "H3_" + upperName + "_DESC";
            item.loreToken = "H3_" + upperName + "_LORE";

            item.tags = new ItemTag[]{ ItemTag.Damage }; // Also change these when making a new item
            item.deprecatedTier = ItemTier.Tier1;
            item.canRemove = true;
            item.hidden = false;

            item.pickupModelPrefab = LoadPrefab();
            item.pickupIconSprite = LoadSprite();

            return item;
        }

        public static ItemDisplayRuleDict CreateDisplayRules() // We've figured item displays out!
        {
            GameObject ItemDisplayPrefab = helpers.PrepareItemDisplayModel(PrefabAPI.InstantiateClone(LoadPrefab(), LoadPrefab().name + "Display", false));

            ItemDisplayRuleDict rules = new ItemDisplayRuleDict();
            rules.Add("mdlCommandoDualies", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(-0.00143F, 0.26877F, -0.21102F),
                        localAngles = new Vector3(287.7655F, 359.0663F, 0.85405F),
                        localScale = new Vector3(0.03401F, 0.03401F, 0.03401F)
                    }
                }
            );
            rules.Add("mdlHuntress", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(-0.12696F, 0.24906F, -0.11415F),
                        localAngles = new Vector3(334.8862F, 350.2349F, 63.21348F),
                        localScale = new Vector3(0.02951F, 0.02951F, 0.02951F)
                    }
                }
            );
            rules.Add("mdlToolbot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "UpperArmL",
                        localPos = new Vector3(0.05641F, -0.83053F, -0.79366F),
                        localAngles = new Vector3(340F, 180F, 180F),
                        localScale = new Vector3(0.40457F, 0.40457F, 0.40457F)
                    }
                }
            );
            rules.Add("mdlEngi", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "CannonHeadL",
                        localPos = new Vector3(-0.05685F, 0.32578F, 0.30414F),
                        localAngles = new Vector3(272.1293F, 75.58608F, 104.0319F),
                        localScale = new Vector3(0.06057F, 0.06057F, 0.06057F)
                    }
                }
            );
            rules.Add("mdlMage", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LowerArmR",
                        localPos = new Vector3(0.00001F, 0.18837F, 0.14875F),
                        localAngles = new Vector3(271.546F, 311.5068F, 228.4828F),
                        localScale = new Vector3(0.03702F, 0.03702F, 0.03702F)
                    }
                }
            );
            rules.Add("mdlMerc", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LowerArmR",
                        localPos = new Vector3(0F, 0.20453F, -0.17553F),
                        localAngles = new Vector3(274.9427F, 0F, 0F),
                        localScale = new Vector3(0.04795F, 0.04795F, 0.04795F)
                    }
                }
            );
            rules.Add("mdlTreebot", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "WeaponPlatform",
                        localPos = new Vector3(0F, 0.00573F, -0.01108F),
                        localAngles = new Vector3(297.403F, 0F, 0F),
                        localScale = new Vector3(0.09541F, 0.09541F, 0.09541F)
                    }
                }
            );
            rules.Add("mdlLoader", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "MechLowerArmR",
                        localPos = new Vector3(0F, 0.4249F, -0.20183F),
                        localAngles = new Vector3(270.8499F, 180F, 180F),
                        localScale = new Vector3(0.06259F, 0.06259F, 0.06259F)
                    }
                }
            );
            rules.Add("mdlCroco", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "UpperArmR",
                        localPos = new Vector3(2.53586F, 0.1137F, -0.20511F),
                        localAngles = new Vector3(21.94774F, 180F, 95.33041F),
                        localScale = new Vector3(0.50713F, 0.50713F, 0.50912F)
                    }
                }
            );
            rules.Add("mdlCaptain", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "LowerArmL",
                        localPos = new Vector3(-0.00004F, 0.38799F, -0.11411F),
                        localAngles = new Vector3(279.1595F, 266.619F, 93.42457F),
                        localScale = new Vector3(0.04857F, 0.04857F, 0.04857F)
                    }
                }
            );
            rules.Add("mdlBandit2", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Hat",
                        localPos = new Vector3(-0.00004F, 0.14609F, -0.00874F),
                        localAngles = new Vector3(347.6882F, 0F, 0F),
                        localScale = new Vector3(0.02929F, 0.02929F, 0.02929F)
                    }
                }
            );
            rules.Add("EngiTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(0.94282F, 0.52725F, 0.88374F),
                        localAngles = new Vector3(0F, 0F, 269.9613F),
                        localScale = new Vector3(0.12399F, 0.12399F, 0.12399F)
                    }
                }
            );
            rules.Add("EngiWalkerTurretBody", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Head",
                        localPos = new Vector3(-1.04651F, 0.8786F, 0F),
                        localAngles = new Vector3(0F, 0F, 90.61157F),
                        localScale = new Vector3(0.17659F, 0.17659F, 0.17659F)
                    }
                }
            );
            rules.Add("mdlScav", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Weapon",
                        localPos = new Vector3(4.60376F, 11.93568F, 2.19924F),
                        localAngles = new Vector3(89.73312F, 0.00146F, 292.9619F),
                        localScale = new Vector3(0.95553F, 0.95553F, 0.95553F)
                    }
                }
            );
            rules.Add("mdlRailGunner", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "Backpack",
                        localPos = new Vector3(-0.13737F, 0.4806F, 0.02754F),
                        localAngles = new Vector3(0F, 312.7892F, 0F),
                        localScale = new Vector3(0.04324F, 0.04204F, 0.04204F)
                    }
                }
            );
            rules.Add("mdlVoidSurvivor", new RoR2.ItemDisplayRule[]{new RoR2.ItemDisplayRule{
                        ruleType = ItemDisplayRuleType.ParentedPrefab,
                        followerPrefab = ItemDisplayPrefab,
                        childName = "MuzzleMegaBlaster",
                        localPos = new Vector3(-0.03047F, 0.21155F, -0.13021F),
                        localAngles = new Vector3(0F, -0.00001F, 0F),
                        localScale = new Vector3(0.06786F, 0.06786F, 0.06786F)
                    }
                }
            );

            return rules;
        }

        public static void AddTokens(float atgDamageStack, int hitRequirement)
        {
            float atgDamageStack_Readable = atgDamageStack * 100;

            LanguageAPI.Add("H3_" + upperName + "_NAME", "AtG Prototype");
            LanguageAPI.Add("H3_" + upperName + "_PICKUP", "Every ten hits, fire a missile.");
            LanguageAPI.Add("H3_" + upperName + "_DESC", "After inflicting <style=cIsUtility>" + hitRequirement + "</style> hits, fire a missile that deals <style=cIsDamage>" + atgDamageStack_Readable + "%</style> <style=cStack>(+" + atgDamageStack_Readable + "% per stack)</style> TOTAL damage.");
            LanguageAPI.Add("H3_" + upperName + "_LORE", "Order: AtG Missile Launcher Prototype\nTracking Number: 11******\nEstimated Delivery: 08/15/2056\nShipping Method: Priority\nShipping Address: Cargo Bay 1-A, Terminal 2-A, UES Port\nShipping Details:\n\nThe AtG Missile Launcher MK1 is a staple for our military operations, but like many wrist rockets and shoulder-mounted launchers, it suffers a safety issue with its targeting scheme. As the missiles are heat-seeking, it can often be thrown off by variance in local temperatures, which is a common issue at our deployment locations. This also renders the missiles ineffective against targets who can manipulate cold and ice, which was admittedly unprecedented.\n\nAdditionally, while the ATG has safeguards against seeking its holder, these fall apart when the launcher sustains heavy damage or even a temporary power outage. This has resulted in a number of unfortunate accidents. We'll need to have a look at the AtG's predecessor models, because clearly something was [REDACTED] up along the way.");
        }

        private static void AddHooks(ItemDef itemDefToHooks, float atgDamageStack, int hitRequirement) // Insert hooks here
        {
            BuffIndex atgBuffIndex = new BuffIndex();
            void GetAtgIndex()
            {
                foreach (BuffDef def in BuffCatalog.buffDefs)
                {
                    if (def == atgCounter)
                    {
                        atgBuffIndex = def.buffIndex;
                    }
                }
            }
            RoR2Application.onLoad += GetAtgIndex;

            On.RoR2.GlobalEventManager.OnHitEnemy += (orig, self, damageInfo, victim) =>
            {
                if (damageInfo.attacker && damageInfo.attacker.GetComponent<CharacterBody>() != null && damageInfo.attacker.GetComponent<CharacterBody>().inventory && damageInfo.procCoefficient > 0f)
                {
                    CharacterBody attackerBody = damageInfo.attacker.GetComponent<CharacterBody>();
                    Inventory attackerInventory = attackerBody.inventory;

                    if (attackerBody.GetBuffCount(atgCounter) == 0)
                    {
                        attackerBody.SetBuffCount(atgBuffIndex, 1);
                    }
                    if (attackerInventory.GetItemCount(itemDefToHooks) > 0)
                    {
                        attackerBody.AddBuff(atgCounter);
                        if (attackerBody.GetBuffCount(atgCounter) >= hitRequirement)
                        {
                            float damageCoefficient = atgDamageStack * (float)attackerInventory.GetItemCount(itemDefToHooks);
                            float missileDamage = Util.OnHitProcDamage(damageInfo.damage, attackerBody.damage, damageCoefficient);
                            MissileUtils.FireMissile(
                                attackerBody.corePosition, 
                                attackerBody, 
                                damageInfo.procChainMask, 
                                victim, 
                                missileDamage, 
                                damageInfo.crit, 
                                GlobalEventManager.CommonAssets.missilePrefab, 
                                DamageColorIndex.Item, 
                                true);
                            attackerBody.SetBuffCount(atgBuffIndex, 1);
                        }
                    }
                }
                orig(self, damageInfo, victim);
            };
        }

        public static BuffDef atgCounter { get; private set; }
        public static void AddBuffs()
        {
            atgCounter = ScriptableObject.CreateInstance<BuffDef>();
            atgCounter.buffColor = new Color(0.3f, 0.9f, 0.3f);
            atgCounter.canStack = true;
            atgCounter.isDebuff = false;
            atgCounter.name = "ATGCounter";
            atgCounter.isHidden = true;
            atgCounter.iconSprite = Main.MainAssets.LoadAsset<Sprite>("Assets/Materials/Icons/ATGIcon.png"); // Change this
            ContentAddition.AddBuffDef(atgCounter);
        }

        public static void Initiate(float atgDamageStack, int hitRequirement) // Finally, initiate the item and all of its features
        {
            CreateItem();
            ItemAPI.Add(new CustomItem(itemDefinition, CreateDisplayRules()));
            AddTokens(atgDamageStack, hitRequirement);
            AddBuffs();
            AddHooks(itemDefinition, atgDamageStack, hitRequirement);
        }
    }
}
