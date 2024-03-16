import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 100;
  marginImg: number = 2;
  exibirImagem: boolean = true;
  private _filtroLista: string = '';


  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  filtrarEventos(filtrarPor: string){
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (      evento: { tema: string;local:string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }
  constructor( private http: HttpClient) {}
  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos").subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos
      },
      error =>console.log(error)
    )
    
  }

}
