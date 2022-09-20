import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

type eventoDB = {
  EventoId: number;
  Local: string;
  DataEvento: string;
  Tema: string;
  QtdPessoas: number;
  Lote: string;
  ImagemURL: string;
}
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {

  public imgUrl = "http://lorempixel.com.br/170/70/"
  public eventos: any = [];
  isCollapsed = true;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{


    this.http.get("https://localhost:5001/api/evento").subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );



  }

}
