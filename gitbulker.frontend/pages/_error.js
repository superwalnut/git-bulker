import Layout from '../components/Layout';
import { Container } from 'react-bootstrap';

export default function Error() {
  return (
    <Layout>
      <Container className="text-center">
        <h1 class="mt-5">Oh No Error!</h1>
        <p>There is an error.</p>
      </Container>
    </Layout>
  );
}