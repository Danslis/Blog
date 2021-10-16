import {Component, Input, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { faPenSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Subscription } from 'rxjs';
import { Post } from 'src/app/interfaces/postResponse';
import { PostsService } from 'src/app/service/post.service';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  @Input() post: Post;
  faPenSquare = faPenSquare;
  faTrash = faTrash;
  aSub!: Subscription;

  constructor( private router: Router, private postsService: PostsService) { }

  ngOnInit() {
  }

  onEditClick(post: Post){
    this.router.navigate(['edit-post',post.id]);
  }

  onDeleteClick(id: number){
    this.aSub =
    this.postsService.deletePost(id)
      .subscribe((id: number) => {
        if (id)
        console.log(id);
      }, error => {
        console.log(error);
      });
  }

}
