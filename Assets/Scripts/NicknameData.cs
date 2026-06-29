using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NicknameData", menuName = "ScriptableObjects/NicknameData")]
public class NicknameData : ScriptableObject
{
    // ÖZEL LAKAPLAR
    public Dictionary<string, string> specialNicknames = new Dictionary<string, string>
    {
        { "stepCount",                "Carpet Burner" },
        { "coffeeCount",              "Caffeine Pusher" },
        { "inkCount",                 "Ink Monkey" },
        { "azarlanmaCount",           "Punching Bag" },
        { "birdOnHeadSeconds",        "Certified Bird Person" },
        { "vantOnHeadSeconds",        "Self Cooling Unit" },
        { "employeesSleepingSeconds", "Human Lullaby" },
        { "sitandstandupCount",       "Human Yo-Yo" },
        { "mailCount",                "Pigeon" },
        { "employeeAngerSeconds",     "Walking Red Flag" },
    };

    // GRUP STATLARI
    public List<string> dutyStats = new List<string>
    {
        "coffeeCount", "inkCount", "mailCount"
    };

    public List<string> absurdityStats = new List<string>
    {
        "birdOnHeadSeconds", "vantOnHeadSeconds", "sitandstandupCount", "stepCount"
    };

    public List<string> sufferingStats = new List<string>
    {
        "azarlanmaCount", "employeeAngerSeconds", "employeesSleepingSeconds"
    };

    // MAKSIMUMLAR (oyunu oynayınca doldur)
    public Dictionary<string, float> maxValues = new Dictionary<string, float>
    {
        { "stepCount",                6000f },
        { "coffeeCount",              6f },
        { "inkCount",                 6f },
        { "azarlanmaCount",           3f },
        { "birdOnHeadSeconds",        50f },
        { "vantOnHeadSeconds",        50f },
        { "employeesSleepingSeconds", 120f },
        { "sitandstandupCount",       6f },
        { "mailCount",                6f },
        { "employeeAngerSeconds",     40f },
    };

    // 27 LAKAP TABLOSU
    public Dictionary<string, string> nicknames = new Dictionary<string, string>
    {
        { "LOW_LOW_LOW",    "Who Are You Again" },
        { "LOW_LOW_MID",    "Not Even Trying" },
        { "LOW_LOW_HIGH",   "Life's Favorite Target" },
        { "LOW_MID_LOW",    "Somehow Still Employed" },
        { "LOW_MID_MID",    "A Walking Mistake" },
        { "LOW_MID_HIGH",   "Please Go Home" },
        { "LOW_HIGH_LOW",   "Delightfully Useless" },
        { "LOW_HIGH_MID",   "A Cry For HR" },
        { "LOW_HIGH_HIGH",  "The Living Incident" },
        { "MID_LOW_LOW",    "Doing The Bare Minimum" },
        { "MID_LOW_MID",    "Fine I Guess" },
        { "MID_LOW_HIGH",   "Tried Really Hard" },
        { "MID_MID_LOW",    "Accidentally Competent" },
        { "MID_MID_MID",    "Average At Everything" },
        { "MID_MID_HIGH",   "The Struggling Normal" },
        { "MID_HIGH_LOW",   "Surprisingly Functional" },
        { "MID_HIGH_MID",   "Chaotic But Present" },
        { "MID_HIGH_HIGH",  "Held Together By Coffee" },
        { "HIGH_LOW_LOW",   "Model Employee" },
        { "HIGH_LOW_MID",   "Quietly Suffering" },
        { "HIGH_LOW_HIGH",  "Works Hard Gets Nothing" },
        { "HIGH_MID_LOW",   "Suspiciously Productive" },
        { "HIGH_MID_MID",   "Chaos With A To-Do List" },
        { "HIGH_MID_HIGH",  "Dedicated To A Fault" },
        { "HIGH_HIGH_LOW",  "Too Busy To Break Down" },
        { "HIGH_HIGH_MID",  "The Unstoppable Disaster" },
        { "HIGH_HIGH_HIGH", "Employee Of The Apocalypse" },
    };

    // RULEBOOK CÜMLELERİ
    public Dictionary<string, List<string>> rulebookLines = new Dictionary<string, List<string>>
    {
        { "birdOnHeadSeconds", new List<string> {
            "It stayed long enough to build a nest. That explains the slow walking. This was not a smart move.",
            "This is an office, not a nature reserve. Whatever bond you two have, keep it off company property.",
            "Befriending office birds is a slippery slope. Consider this a formal warning.",
            "Your head is a work tool. At least it was supposed to be.",
            "Your relationship with the bird has been added to HR's agenda. Details to follow.",
        }},
        { "vantOnHeadSeconds", new List<string> {
            "The dedication to keeping employees awake is admirable. Your spine disagrees.",
            "Are you cooling the computers or just enjoying the breeze? Either way, people are starting to talk.",
            "Reports of a fan being physically attached to your head have reached management. Investigation pending.",
            "Ventilating the office is not in your job description. Nobody told you that apparently.",
            "The last person who did this no longer works here. Nobody knows where they went.",
        }},
        { "mailCount", new List<string> {
            "Maybe the workload is heavy, or maybe people are forwarding their personal mail to you. Either way, check yourself before you get fired.",
            "The birds are rioting. Feathers everywhere. The cleaning staff has filed three complaints.",
            "Reports of forced bird labor are piling up. It's only a matter of time before they trace it back to you.",
            "If this many mails require this many birds, HR has bigger problems than you.",
            "The birds' overtime has shown up in the budget. Accounting would like a word.",
        }},
        { "stepCount", new List<string> {
            "There must be a reason for all that walking. Hopefully it's work related.",
            "You've memorized the office layout and you're still getting lost. Explain yourself.",
            "Your step count broke a record today. Were you working or were you running from something?",
            "This much walking means either very hard work or a very long escape attempt. Both are concerning.",
            "Your shoes put in more hours than most of your colleagues today.",
        }},
        { "coffeeCount", new List<string> {
            "You didn't drink any of it. You handed it all out. So why do you look like that.",
            "The coffee machine learned your name today. This is not a good sign.",
            "You made a lot of friends or a lot of dependents today. The difference matters.",
            "Coffee is a motivational tool, not a bribe. You may have crossed that line.",
            "Someone who gives out this much coffee is either very loved or very scared. Both are valid.",
        }},
        { "inkCount", new List<string> {
            "The printer survived today because of you. It will not thank you. It never does.",
            "Refilling ink was not your job. But nobody else was going to do it so here we are.",
            "Ink refilling is an art form. You were an artist today. Nobody noticed.",
            "The printer has no other friends. This is sad for both of you.",
            "This much ink means either a lot of work or a lot of mistakes. We'd rather not know which.",
        }},
        { "azarlanmaCount", new List<string> {
            "Getting yelled at this many times requires a very specific talent. Congratulations.",
            "At least the boss knows you exist. Look on the bright side.",
            "Every scolding is a learning opportunity. You learned a lot today.",
            "You broke the record. There is no trophy for this category.",
            "Either very brave or very unaware. We respect both equally.",
        }},
        { "sitandstandupCount", new List<string> {
            "This many sit-stands means either great energy or a complete inability to commit. Both are worrying.",
            "Your chair saw things today. It cannot speak. But it saw things.",
            "Ergonomics experts would cry looking at this report.",
            "You sat down and stood up more times than most people make decisions in a week.",
            "Office record broken. This information will not be useful to anyone.",
        }},
        { "employeesSleepingSeconds", new List<string> {
            "They slept while waiting for you. We don't want to know what they do when you're around.",
            "Where were you while your team was asleep. We had to ask.",
            "Getting this much done with a sleeping team is impressive. Or nothing got done. Hard to tell.",
            "Your team's sleep hours have exceeded acceptable limits. We suggest reconsidering your leadership style.",
            "Some say a sleeping employee is a happy employee. Those people have never been to this office.",
        }},
        { "employeeAngerSeconds", new List<string> {
            "This much collective rage means either a very stressful workplace or a very long wait. Both are your fault.",
            "We considered organizing an anger management seminar. Your name is at the top of the list.",
            "Your team's meltdown duration broke a record today. You're an inspiration. Somehow.",
            "You kept them waiting this long and you're still employed. That takes guts. Or something else.",
            "An employee in a meltdown is an unproductive employee. Today's losses cannot be calculated.",
        }},
    };
}