import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public evento:any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{
    /*this.eventos = [
      {
        Tema: 'Angular',
        Local: 'Edson Ramalho',
        Empresa: 'Minsait'
      },
      {
        Tema: 'React',
        Local: 'General Paulo',
        Empresa: 'Tempest'
      },
      {
        Tema: 'Vue',
        Local: 'Camilo Holanda',
        Empresa: 'SolMais'
      },
      {
        Tema: 'Django',
        Local: 'Barão passagem',
        Empresa: 'EraTec'
      },
    ]*/
    this.http.get("https://localhost:5001/api/evento").subscribe(
      response => this.evento = response,
      error => console.log(error)
    );



  }

}
