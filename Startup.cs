using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CadastroCursos.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CursosProfissionalizantes {
    public class Startup {
        IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<EscolaContexto> (options => options.UseSqlServer (Configuration.GetConnectionString ("BancoEscolaEF")));
            services.AddMvc ();

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info {
                    Version = "v1",
                        Title = "Api Cursos Online",
                        Description = "Documentação da Api Cursos Online",
                        TermsOfService = "None",
                        Contact = new Contact {
                            Name = "Jéssica Souza",
                            Email = "jessica.jdss@gmail.com",
                        }
                });
                 var caminhoBase = AppContext.BaseDirectory;
                 var caminhoXml = Path.Combine (caminhoBase, "CursosOnline.xml");
                 c.IncludeXmlComments (caminhoXml);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseSwagger ();

            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "API Cursos Online");
            });

            app.UseMvc ();
            
            app.Run (async (context) => {
                await context.Response.WriteAsync ("Você saiu da rota");
            });
        }
    }
}