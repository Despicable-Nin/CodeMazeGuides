﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace GenerateStreamFromStringInCSharp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class GenerateStreamFromStringBenchmark
    {
        private const string BenchmarkString
        = """
        Sed facilisis justo quam, ornare varius tellus dapibus sit amet. Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Nullam aliquam auctor fringilla. Nam id orci lacus. Sed placerat justo vitae sem auctor, ac molestie lacus sodales. 
        Nullam tincidunt lacus ex, ac hendrerit elit tincidunt in. Integer tincidunt accumsan nisl, id aliquet leo convallis in. 
        Morbi pulvinar odio et est vulputate viverra. Maecenas nibh libero, sollicitudin quis ex ut, egestas auctor mi. 
        Fusce varius facilisis mauris, ut volutpat libero volutpat in. Aliquam faucibus hendrerit nibh vel porttitor. 
        Suspendisse et laoreet tellus. Suspendisse posuere venenatis ligula in viverra. Aenean aliquet vitae erat eu molestie.
        Ut tempus ac erat id condimentum. Pellentesque mi purus, interdum a diam sit amet, scelerisque elementum orci.
        Vestibulum sagittis magna eu lectus suscipit congue. Quisque a diam vitae tortor sodales tristique.
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis ac erat id justo gravida efficitur quis in orci.
        Integer porttitor est ex, nec porttitor turpis malesuada vel. Vestibulum molestie aliquet felis, a sagittis ante viverra sed.
        Donec eget urna in quam viverra mattis nec non neque. Phasellus eu iaculis velit. Nunc varius varius lorem, nec iaculis magna varius in.
        Cras rutrum purus diam, porttitor imperdiet justo pulvinar vitae.

        Integer ac est posuere enim suscipit efficitur. Donec vehicula velit at neque porta, nec bibendum tellus pulvinar.
        Duis accumsan libero orci, eu viverra turpis facilisis in. Donec varius nulla eros, ut tincidunt risus lobortis vel.
        Quisque sed tellus vel purus gravida pharetra. Donec at magna vitae diam iaculis fringilla vel in turpis.
        Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis eget aliquam augue, non molestie felis.
        Donec erat ipsum, iaculis vestibulum tortor a, eleifend consequat velit. Mauris imperdiet feugiat dolor, ut porttitor neque tempus a.
        Morbi quam elit, consectetur sit amet hendrerit non, viverra et ante. Fusce et finibus quam.
        Integer ut risus quis eros malesuada vestibulum at nec augue. Quisque semper consequat dapibus.
        Praesent porttitor lectus quis dolor laoreet eleifend. Sed felis risus, ultricies at iaculis eu, fringilla quis ex.
        Integer ut rutrum magna, id vulputate massa. Curabitur ut tristique felis, eget sagittis massa.
        Vestibulum pharetra purus at lorem dignissim, vel tempus tortor tempor. Nunc varius mauris eget imperdiet vehicula.
        Sed vel orci a ex bibendum congue sit amet ut arcu.

        Proin scelerisque, erat at laoreet pharetra, orci nulla efficitur quam, nec elementum turpis leo quis dolor
        Proin vel magna sed nisl consectetur aliquam. Maecenas maximus metus id efficitur cursus. Sed luctus vulputate magna non aliquet.
        In vitae dolor lorem. Quisque ut nisl faucibus, sollicitudin ex non, vehicula enim.
        Integer facilisis ex libero, ut suscipit leo blandit non. Vivamus nec ipsum orci. Proin nec mauris dui.
        Proin at felis et eros commodo aliquet. Pellentesque lacinia porta leo, non accumsan turpis sagittis et.
        Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; 
        Integer a purus scelerisque, sagittis est quis, mattis libero. Proin urna eros, feugiat non diam ac, tempus vulputate nibh.
        Nulla nec orci ut odio ornare egestas molestie id ex.

        Maecenas in sapien enim. Curabitur consectetur efficitur eros, at maximus ipsum euismod a.
        Curabitur mi est, malesuada sed dignissim quis, vestibulum vitae mi. Cras placerat neque dui, et feugiat ex imperdiet eu.
        Sed nec metus non turpis vehicula finibus. Nulla vestibulum ullamcorper urna sed egestas. Phasellus eget aliquam risus.
        Proin fermentum pellentesque ullamcorper. Fusce lobortis, lorem vitae sagittis aliquam, nisl nisl vulputate diam,
        vel rhoncus ipsum sapien non metus. Aliquam erat volutpat. Maecenas et molestie nulla, et tincidunt lectus.
        Maecenas iaculis lacinia orci sit amet pretium. Sed semper eros nec erat malesuada consequat.
        Morbi porta nunc in dui tristique, a eleifend nibh tincidunt. Nullam ut lorem ac lacus rhoncus molestie a a sapien.

        Nam mi tellus, dapibus ac sagittis nec, pharetra eget mauris. Proin porttitor placerat mauris sed dictum.
        Fusce vel tincidunt augue. Morbi elementum elementum nulla ultrices vestibulum. Curabitur lobortis eu odio et fermentum.
        Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed sit amet leo vel felis condimentum
        condimentum quis nec dui. In pulvinar ligula turpis, ut placerat metus posuere a. Nunc bibendum orci et metus consectetur viverra.
        Curabitur non tellus sed nisl vehicula pulvinar. Praesent a leo ipsum.

        Sed in turpis vel lacus faucibus volutpat a quis orci. Nam varius ante at est feugiat interdum. Etiam egestas molestie fermentum.
        Donec leo ligula, varius vel placerat vel, finibus nec lectus. Etiam ac justo quis lacus accumsan efficitur ut tincidunt nulla.
        Integer fringilla tellus a vehicula aliquet. Nulla ut laoreet lectus, et congue lacus. Mauris venenatis odio sit amet felis euismod,
        ut consequat justo suscipit. Praesent bibendum aliquet metus, facilisis tincidunt tortor ultricies eget. Nullam ut quam scelerisque
        purus sagittis feugiat. Quisque imperdiet felis ac dui posuere semper. Integer hendrerit justo at metuscondimentum semper.

        Maecenas at finibus ante. Mauris dapibus nisl dictum arcu porta, varius tempus nunc volutpat. Quisque bibendum metus nec metus malesuada,
        quis lobortis elit convallis. Sed ut tortor volutpat, accumsan justo in, interdum mauris. Curabitur in magna nulla. Integer condimentum,
        quam id malesuada lacinia, ligula lorem fermentum nisl, ac lacinia purus justo aliquam elit. Suspendisse potenti.
        Donec luctus lacus vel malesuada vestibulum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
        Sed bibendum in nisi quis tristique. Fusce fringilla sem nec dui porta scelerisque. Nulla placerat elit vel metus dictum tincidunt
        id quis ipsum. Cras a nisi nec ligula viverra pellentesque ut et enim. Donec est mi, volutpat et mattis non, interdum ut nibh. 
        Sed auctor porttitor consequat. Cras malesuada lectus dolor, ut cursus nisi ultrices a. Morbi varius dolor nec magna lacinia, 
        eget bibendum metus volutpat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. 
        Ut accumsan malesuada leo a luctus. Praesent in vestibulum eros, et ultricies est. Proin at sodales quam, eget varius dui. 
        Proin semper augue vel purus consequat consectetur.
        """;

        [Benchmark]
        public void GetStreamWithStreamWriter()
            => GenerateStreamFromStringMethods.GetStreamWithStreamWriter(BenchmarkString);

        [Benchmark]
        public void GetStreamWithGetBytes()
            => GenerateStreamFromStringMethods.GetStreamWithGetBytes(BenchmarkString);
    }
}