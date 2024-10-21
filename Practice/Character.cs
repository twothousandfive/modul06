using System;
using System.Collections.Generic;

// Интерфейс ICloneable для всех клонируемых объектов
public interface ICloneable<T>
{
    T Clone();
}

// Класс Weapon (Оружие)
public class Weapon : ICloneable<Weapon>
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public Weapon Clone()
    {
        // Создаем глубокую копию объекта
        return new Weapon(this.Name, this.Damage);
    }

    public override string ToString()
    {
        return $"Weapon(Name: {Name}, Damage: {Damage})";
    }
}

// Класс Armor (Броня)
public class Armor : ICloneable<Armor>
{
    public string Name { get; set; }
    public int Defense { get; set; }

    public Armor(string name, int defense)
    {
        Name = name;
        Defense = defense;
    }

    public Armor Clone()
    {
        // Создаем глубокую копию объекта
        return new Armor(this.Name, this.Defense);
    }

    public override string ToString()
    {
        return $"Armor(Name: {Name}, Defense: {Defense})";
    }
}

// Класс Skill (Способность)
public class Skill : ICloneable<Skill>
{
    public string Name { get; set; }
    public string SkillType { get; set; }

    public Skill(string name, string skillType)
    {
        Name = name;
        SkillType = skillType;
    }

    public Skill Clone()
    {
        return new Skill(this.Name, this.SkillType);
    }

    public override string ToString()
    {
        return $"Skill(Name: {Name}, Type: {SkillType})";
    }
}

public class Character : ICloneable<Character>
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intellect { get; set; }

    public Weapon Weapon { get; set; }
    public Armor Armor { get; set; }
    public List<Skill> Skills { get; set; } = new List<Skill>();

    public Character(string name, int health, int strength, int agility, int intellect)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Agility = agility;
        Intellect = intellect;
    }

    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }

    public Character Clone()
    {
        Character clonedCharacter = new Character(this.Name, this.Health, this.Strength, this.Agility, this.Intellect)
        {
            Weapon = this.Weapon?.Clone(),  // Клонируем оружие, если оно есть
            Armor = this.Armor?.Clone()     // Клонируем броню, если она есть
        };

        // Клонируем все способности
        foreach (var skill in this.Skills)
        {
            clonedCharacter.AddSkill(skill.Clone());
        }

        return clonedCharacter;
    }
}

