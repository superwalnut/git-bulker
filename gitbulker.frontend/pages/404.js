import Layout from '../components/Layout';
import { Container } from 'react-bootstrap';

export default function NotFound() {
  return (
    <Layout>
      <Container className="text-center">
        <img src={"/404.gif"} width="300px" />
        <h1 class="mt-5">Oh No 404! Page not found.</h1>
        <p>The site configured at this address does not contain the requested file.</p>
      </Container>
    </Layout>
  );
}