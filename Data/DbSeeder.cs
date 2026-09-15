using BonWeb.Models;

namespace BonWeb.Data;

public static class DbSeeder
{
    public static void SeedProducts(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();

        var grains = categories.FirstOrDefault(c => c.Name == "Зрнести производи");
        var coffee = categories.FirstOrDefault(c => c.Name == "Кафе");
        var nuts = categories.FirstOrDefault(c => c.Name == "Апетисани");
        var peanuts = categories.FirstOrDefault(c => c.Name == "Кикирики");
        var fruits = categories.FirstOrDefault(c => c.Name == "Суво овошје");
        var cooking = categories.FirstOrDefault(c => c.Name == "BON Cooking");

        if (grains == null || coffee == null || nuts == null ||
            peanuts == null || fruits == null || cooking == null)
        {
            return;
        }

        AddProduct(context, "Црвена леќа", "Леќата е одличен извор на протеин и витамини корисни за нашето тело. Лесна за готвење и вкусна за јадење. Зелената како и црвената леќа се со исти хранливи вредности.", 60,
            "/Images/Products/crvena-lekja.png", grains.Id);

        AddProduct(context, "Грав", "Еве малку поприродно и повеќе како опис за производ:\n\n**Гравот е една од најпознатите и најзастапените намирници во традиционалната кујна. Богат е со растителни протеини и влакна, а неговиот препознатлив вкус го прави одличен избор за тавче-гравче, чорби, салати и многу други јадења.**\n", 70,
            "/Images/Products/grav.png", grains.Id);

        AddProduct(context, "Пченица", "Пченицата е погодна за секакви рецепти. Лесна и здрава за јадење, Бон ја нуди во својата најприродна форма.", 50,
            "/Images/Products/pcenica.png", grains.Id);

        AddProduct(context, "Зелена леќа", "Леќата е одличен извор на протеин и витамини корисни за нашето тело. Лесна за готвење и вкусна за јадење. Зелената како и црвената леќа се со исти хранливи вредности.", 60,
            "/Images/Products/zelena-lekja.png", grains.Id);

        AddProduct(context, "Пченка за пуканки", "За љубителите на мирисот на домашни пуканки имаме Бон решение. Нашата високо квалитетна пченка за пуканки е одлична за готвење на највкусните пуканки.", 100,
            "/Images/Products/pcenka za pukanki.png", grains.Id);

        AddProduct(context, "BON 3 во 1 ICE", "BON 3 во 1 ICE е освежително инстант кафе создадено за уживање во ладните моменти. Совршена комбинација од кафе, млеко и шеќер, со богат и кремаст вкус кој се подготвува брзо и лесно.", 20,
            "/Images/Products/ice 3in1.png", coffee.Id);

        AddProduct(context, "BON Caffe Classic 450g", "BON Classic е традиционално кафе со богат вкус и препознатлива арома, создадено за вистинско уживање во секоја шолја. Внимателно избраните зрна кафе овозможуваат полн и пријатен вкус, идеален за секојдневните кафе моменти.", 150,
            "/Images/Products/classic-450g.png", coffee.Id);

        AddProduct(context, "BON Caffe Classic 100g", "BON Classic е традиционално кафе со богат вкус и препознатлива арома, создадено за вистинско уживање во секоја шолја. Внимателно избраните зрна кафе овозможуваат полн и пријатен вкус, идеален за секојдневните кафе моменти.", 150,
            "/Images/Products/classic-100g.png", coffee.Id);

        AddProduct(context, "Espresso Classico 1000g", "Espresso Classico е кафе во зрно со интензивна арома и полн, избалансиран вкус. Создадено за подготовка на квалитетно еспресо со богата крема, идеално за добар почеток на денот или кратка кафе пауза.", 550,
            "/Images/Products/espresso-classico.png", coffee.Id);

        AddProduct(context, "Леблебија", "Леблебијата е одлична за дигестија, и изобилува со витамини важни за човечките коски. Грицкај Бон леблебија и уживај во нејзините придобивки.", 90,
            "/Images/Products/leblebija.png", nuts.Id);

        AddProduct(context, "Леблебија со суво грозје", "Овој микс од леблебија и суво грозје е одличен за сечиј вкус. Балансирана мешавина од солено и благо го оправдува нашиот универзум од вкусови.", 100,
            "/Images/Products/leblebija-i-suvo-grozje.png", nuts.Id);

        AddProduct(context, "Ф'стак", "Богат со антиоксиданси и природен протеин, Бон Ф'стакот е незаменлив придружник на твоето здравје. Грицкањето на нашиот ф'стак носи само бенефити за здравјето.", 90,
            "/Images/Products/fstaci.png", nuts.Id);

        AddProduct(context, "Лешник", "Лешникот на Бон, вкусен јадкаст производ кој е богат со витамини важни за нашето тело. Може да се искористи во најразлични рецепти, но и да се грицка.", 100,
            "/Images/Products/lesnik.png", nuts.Id);

        AddProduct(context, "Flips кикирики", "Еден од нашите понови производи наменет за уживање е Бон Флипсот. Крцкави, зачинети и вкусни топчиња флипс е она што ти треба за безгрижно да грицкаш.", 40,
            "/Images/Products/flips.png", peanuts.Id);

        AddProduct(context, "Кикирики во лушпа", "За оние кои сакаат занимација покрај грицкањето, Бон кикириката во лушпа е одличен избор. Крцкава и солена со неоддолив вкус.", 65,
            "/Images/Products/kikirika-luspa.png", peanuts.Id);

        AddProduct(context, "Пикант кикирики", "За љубителите на пикантно, Бон пикант кикириката е вистински предизвик. Крцкаво печена кикирика со додаден лут зачин е неоддолив предизвик за тебе.", 30,
            "/Images/Products/pikant-kikirika.png", peanuts.Id);

        AddProduct(context, "Кикирики", "Крцкаво печени, а внимателно посолени ја прават нашата печена и солена Бон кикирка да остави длабок впечаток за вашиот бкус. Одлична високо протеинска закуска е токму нашата кикирика.", 30,
            "/Images/Products/kikiriki.png", peanuts.Id);

        AddProduct(context, "Брусница", "Сувата брусница на Бон е одличен антиоксидант и витаминска закуска за секој дел од денот. Вкусна и блага пауза со Бон е она што ви треба.", 85,
            "/Images/Products/brusnica.png", fruits.Id);

        AddProduct(context, "Сува кајсија", "Покрај тоа што се суви, изобилуваат со минерали и го оддржуваат здравјето кај човекот. Сувите кајсии на Бон се вкусен начин да внесете здравје.", 100,
            "/Images/Products/suva kajsija.png", fruits.Id);

        AddProduct(context, "Сува смоква", "Овој сладок производ на Бон ќе ве заслади и ќе му даде се што му треба на вашето тело за правилно да функционира. Идеално и здраво решение кога осеќате потреба за нешто слатко.", 120,
            "/Images/Products/suva smokva.png", fruits.Id);

        AddProduct(context, "Свежа урма", "Свежата урма е природно слатко овошје со мек и сочен вкус. Богата со растителни влакна и природни шеќери, таа е одличен избор за брза ужина, додаток во десерти или како природен извор на енергија во текот на денот.", 200,
            "/Images/Products/sveza-urma.png", fruits.Id);

        AddProduct(context, "Густин", "Кога станува збор за слатките рецепти, Бон густинот е високо квалитетен и незаменлив придружник.", 60,
            "/Images/Products/gustin.png", cooking.Id);

        AddProduct(context, "Пченкарно брашно", "За најдобро тесто и незаменливи резултати ви го нудиме најдоброто пченкарно брашно. Бон пченкарното брашно е за сите кои сакаат вкусни и свежи кујнски мајстории.", 160,
            "/Images/Products/pcenkarno brashno.png", cooking.Id);

        AddProduct(context, "Пире од компир", "За инстантно брз и вкусен оброк, Бон инстант пирето од компир е нешто ново и одлично за оние кои сакаат нешто брзо.", 70,
            "/Images/Products/pire.png", cooking.Id);

        AddProduct(context, "Презла", "За страствените готвачи и оние кои сакаат вкусен оброк, Бон лебните трошки се незаменлив дел од вашата кујна.", 100,
            "/Images/Products/prezla.png", cooking.Id);

        AddProduct(context, "Шеќер во прав", "Шеќерот во прав е одличен додаток за вашите колачи и торти. Бон го нуди најквалитетниот шеќер во прав кој вашите рецепти ќе ги направи уште по вкусни.", 60,
            "/Images/Products/seker-vo-prav.png", cooking.Id);
        AddProduct(context, "BON Minas", "BON Minas е традиционално кафе со богата арома и полн, препознатлив вкус. Создадено за љубителите на класичното кафе, идеално е за секојдневно уживање и оние моменти кога добрата шолја кафе е незаменлива.", 180,
            "/Images/Products/minas.png", coffee.Id);

        AddProduct(context, "Чили кикирики", "BON Chilli кикирики се крцкави печени кикирики збогатени со пикантна мешавина од зачини. Интензивниот чили вкус и пријатната лутина ги прават одличен избор за грицкање и за сите љубители на зачинети вкусови.", 60,
            "/Images/Products/chilli.jpg", peanuts.Id);

        AddProduct(context, "Индиски орев", "Индискиот орев е богат со здрави масти и протеини. Изобилува со здрави придобивки и е вистинска причина за да го грицкате нашиот Бон индиски орев.", 120,
            "/Images/Products/indiski-orev.png", nuts.Id);
        

        context.SaveChanges();
    }

    private static void AddProduct(
        ApplicationDbContext context,
        string name,
        string description,
        decimal price,
        string imageUrl,
        int categoryId)
    {
        var product = context.Products.FirstOrDefault(p => p.Name == name);

        if (product == null)
        {
            context.Products.Add(new Product
            {
                Name = name,
                Description = description,
                Price = price,
                ImageUrl = imageUrl,
                CategoryId = categoryId
            });
        }
        else
        {
            product.Description = description;
            product.Price = price;
            product.ImageUrl = imageUrl;
            product.CategoryId = categoryId;
        }
    }
}