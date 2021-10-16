import { Component } from '@angular/core'
import { Observable } from 'rxjs';
import { Post } from 'src/app/interfaces/postResponse';
import { PostsService } from 'src/app/service/post.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent {
  posts$: Observable<Post[]>
  constructor(private postsService: PostsService) {
   }

  ngOnInit(): void {
    this.posts$ = this.postsService.getPosts();
  }
}
