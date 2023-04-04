import Head from 'next/head'
import Image from 'next/image'
import { Inter } from 'next/font/google'
import styles from '@components/styles/Home.module.css'
import CrudButton from '../components/CrudButton/CrudButton'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <>
      <Head>
        <title>Next App</title>
        <meta name="description" content="Generated by create next app" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <main className={styles.main}>
        

        <div className={styles.center}>
          <CrudButton label="Add"/>
          <CrudButton label="View"/>
          <CrudButton label="View All"/>
          <CrudButton label="Edit"/>
          <CrudButton label="Delete"/>
        </div>
      </main>
    </>
  )
}